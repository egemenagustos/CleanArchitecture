using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed record RegisterCommand(string email, string username,string nameLastName, string password) : IRequest<MessageResponse>;
}
