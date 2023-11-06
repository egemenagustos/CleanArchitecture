using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitecture.Application.Service
{
    public interface IUserRoleService
    {
        Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    }
}
