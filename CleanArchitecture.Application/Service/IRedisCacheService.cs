using CleanArchitecture.Domain.Entities;
using GenericRepository;
using StackExchange.Redis;

namespace CleanArchitecture.Application.Service
{
    public interface IRedisCacheService
    {
        IDatabase GetDb();
        List<T> LoadToCacheFromDbAsync<T>(IRepository<T> repository, string key) where T : class;
    }
}
