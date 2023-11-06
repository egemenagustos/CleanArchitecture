using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Application.Service
{
    public interface IRoleService
    {
        Task CreateAsync(CreateRoleCommand request);
    }
}
