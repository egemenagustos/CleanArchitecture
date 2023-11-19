using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Commands.UpdateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Service
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);

        Task UpdateAsync(UpdateCarCommand request, CancellationToken cancellationToken);

        Task<List<Car>> GetAll(GetAllCarQuery getAllCarQueryHandler, CancellationToken cancellationToken);
    }
}
