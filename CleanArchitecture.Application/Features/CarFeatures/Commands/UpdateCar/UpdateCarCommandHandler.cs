using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.UpdateCar
{
    public sealed class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, MessageResponse>
    {
        private readonly ICarService _carService;

        public UpdateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<MessageResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.UpdateAsync(request, cancellationToken);
            return new("Araç başarıyla güncellendi!");
        }
    }
}
