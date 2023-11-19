using CleanArchitecture.Application.Service;
using GenericRepository;
using StackExchange.Redis;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Caching
{
    public sealed class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(string url)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
        }

        public IDatabase GetDb()
        {
            return _connectionMultiplexer.GetDatabase();
        }

        public List<T> LoadToCacheFromDbAsync<T>(IRepository<T> repository, string key) where T : class
        {
            List<T> list = repository.GetAll().ToList();

            IDatabase cacheRepository = GetDb();

            list.ForEach(async l =>
            {
                string? idProperyValue = l.GetType().GetProperty("Id").GetValue(l, null).ToString();
                cacheRepository.HashSet(key, idProperyValue, JsonSerializer.Serialize(l));
                cacheRepository.KeyExpire(key, expiry: DateTime.Now.AddDays(1));
            });

            return list;
        }
    }
}
