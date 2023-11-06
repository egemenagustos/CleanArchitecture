using FluentValidation;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public sealed class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(p => p.userId).NotEmpty().WithMessage("Kullanıcısı bilgisi boş olamaz");
            RuleFor(p => p.userId).NotNull().WithMessage("Kullanıcısı bilgisi boş olamaz");
            RuleFor(p => p.roleId).NotNull().WithMessage("Rol bilgisi boş olamaz");
            RuleFor(p => p.roleId).NotNull().WithMessage("Rol bilgisi boş olamaz");
        }
    }
}
