using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRole userRole = new()
            {
                RoleId = request.roleId,
                UserId = request.userId,
            };
            await _userRoleRepository.AddAsync(userRole,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
