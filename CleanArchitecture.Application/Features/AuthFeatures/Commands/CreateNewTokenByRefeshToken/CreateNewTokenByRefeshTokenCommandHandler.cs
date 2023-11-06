using CleanArchitecture.Application.Features.AuthFeatures.Login;
using CleanArchitecture.Application.Service;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken
{
    public sealed class CreateNewTokenByRefeshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefeshTokenCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public CreateNewTokenByRefeshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefeshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authService.CreateTokenByRefreshTokenAsync(request,cancellationToken);
        }
    }
}
