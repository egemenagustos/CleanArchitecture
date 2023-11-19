using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Commands.UpdateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;
using StackExchange.Redis;
using System.Text.Json;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IDatabase _cacheRepository;
        private const string carKey = "carCaches";

        public CarService(IMapper mapper, IUnitOfWork unitOfWork, ICarRepository carRepository, IRedisCacheService redisCacheService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
            _redisCacheService = redisCacheService;
            _cacheRepository = _redisCacheService.GetDb();
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);
            await _carRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (await _cacheRepository.KeyExistsAsync(carKey))
            {
               await _cacheRepository.HashSetAsync(carKey, car.Id, JsonSerializer.Serialize(car));
            }
        }

        public async Task<List<Car>> GetAll(GetAllCarQuery getAllCarQueryHandler, CancellationToken cancellationToken)
        {
            if (!_cacheRepository.KeyExists(carKey))
                return _redisCacheService.LoadToCacheFromDbAsync(_carRepository,carKey);

            List<Car> list = new();

            HashEntry[] result = _cacheRepository.HashGetAll(carKey);
            foreach(var car in result.ToList())
            {
                Car cars = JsonSerializer.Deserialize<Car>(car.Value);
                list.Add(cars);
            }
            return list;
        }

        public async Task UpdateAsync(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = _carRepository.GetWhere(x => x.Id == request.Id).FirstOrDefault();
            if (car == null)
                throw new Exception("Araba buluanamadı!");

            car.Name = request.Name;
            car.EnginePower = request.EnginePower;
            car.Model = request.Model;

            _carRepository.Update(car);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheRepository.HashSetAsync(carKey, car.Id, JsonSerializer.Serialize(car));
        }
    }
}
