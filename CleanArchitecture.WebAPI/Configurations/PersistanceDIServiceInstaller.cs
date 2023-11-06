using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Service;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Service;
using CleanArchitecture.WebAPI.Middleware;
using GenericRepository;

namespace CleanArchitecture.WebAPI.Configurations
{
    public sealed class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
