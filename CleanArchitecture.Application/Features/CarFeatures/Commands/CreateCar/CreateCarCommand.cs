using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public sealed record CreateCarCommand(string name, string model, int EnginePower) : IRequest<MessageResponse>;
}
