using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Caching;
using CleanArchitecture.WebAPI.OptionsSetup;

namespace CleanArchitecture.WebAPI.Configurations
{
    public sealed class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddSingleton<IRedisCacheService>(sp =>
            {
                return new RedisCacheService(configuration.GetConnectionString("RedisConnection"));
            });
        }
    }
}
