using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.AuthFeatures.Login;

namespace CleanArchitecture.Application.Service
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);

        Task<LoginCommandResponse> LoginAsync(LoginCommand loginCommand, CancellationToken cancellationToken);
        Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefeshTokenCommand createNewTokenByRefeshTokenCommand, CancellationToken cancellationToken);
    }
}
