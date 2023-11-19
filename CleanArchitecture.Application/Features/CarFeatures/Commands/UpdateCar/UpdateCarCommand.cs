using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.UpdateCar
{
    public sealed class UpdateCarCommand : IRequest<MessageResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int EnginePower { get; set; }
    }
}
