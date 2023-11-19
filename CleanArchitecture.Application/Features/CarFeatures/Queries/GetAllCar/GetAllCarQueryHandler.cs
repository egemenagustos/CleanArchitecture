using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<Car>>
    {
        private readonly ICarService _carService;

        public GetAllCarQueryHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            return await _carService.GetAll(request,cancellationToken);
        }
    }
}
