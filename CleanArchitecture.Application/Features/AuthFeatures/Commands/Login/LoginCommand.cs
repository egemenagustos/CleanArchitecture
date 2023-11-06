using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Login
{
    public sealed record LoginCommand(string userNameorEmail, string password) : IRequest<LoginCommandResponse>;
}
