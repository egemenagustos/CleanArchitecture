using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.AuthFeatures.Login;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefeshTokenCommand createNewTokenByRefeshTokenCommand, CancellationToken cancellationToken)
        {
            User? user = await _userManager.FindByIdAsync(createNewTokenByRefeshTokenCommand.userId);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");
            if (user.RefreshToken != createNewTokenByRefeshTokenCommand.refreshToken) throw new Exception("Refresh token geçerli değil!");
            if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh tokenun süresi dolmuş!");

            return await _jwtProvider.CreateTokenAsync(user);
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
             User? user = await _userManager.Users
                .Where(p => p.UserName == loginCommand.userNameorEmail || p.Email == loginCommand.userNameorEmail)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("Kullanıcı bulunamadı");

            bool result = await _userManager.CheckPasswordAsync(user, loginCommand.password);

            if (result)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }
            throw new Exception("Parolanız hatalı!");
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToList().First().Description);
            }
            //List<string> email = new();
            //email.Add(request.email);
            //string body = "";
            //await _mailService.SendMailAsync(email,"Mail Onayı",body,null);
        }
    }
}
