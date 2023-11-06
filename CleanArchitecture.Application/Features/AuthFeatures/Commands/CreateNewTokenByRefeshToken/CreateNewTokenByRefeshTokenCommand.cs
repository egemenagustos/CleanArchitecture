using CleanArchitecture.Application.Features.AuthFeatures.Login;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken
{
    public sealed record CreateNewTokenByRefeshTokenCommand(string userId, string refreshToken) : IRequest<LoginCommandResponse>;
}
