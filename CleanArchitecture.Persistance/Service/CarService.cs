using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);
            await _carRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery getAllCarQueryHandler, CancellationToken cancellationToken)
        {
            return await _carRepository
                 .GetWhere(p => p.Name.ToLower().Contains(getAllCarQueryHandler.Search.ToLower()))
                 .OrderBy(p => p.Name)
                 .ToPagedListAsync(getAllCarQueryHandler.pageNumber, getAllCarQueryHandler.pageSize, cancellationToken);
        }
    }
}
