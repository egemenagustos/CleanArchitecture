using FluentValidation;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Rol adı boş olamaz!");
            RuleFor(p => p.name).NotNull().WithMessage("Rol adı boş olamaz!");
        }
    }
}
