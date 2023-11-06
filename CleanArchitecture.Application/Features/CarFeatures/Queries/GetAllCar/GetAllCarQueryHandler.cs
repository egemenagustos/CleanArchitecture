using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, PaginationResult<Car>>
    {
        private readonly ICarService _carService;

        public GetAllCarQueryHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            return await _carService.GetAllAsync(request,cancellationToken);
        }
    }
}
