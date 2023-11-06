using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.email).NotEmpty().WithMessage("Mail bilgisi boş olamaz!");
            RuleFor(p => p.email).NotNull().WithMessage("Mail bilgisi boş olamaz!");
            RuleFor(p => p.email).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!");

            RuleFor(p => p.username).NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz!");
            RuleFor(p => p.username).NotNull().WithMessage("Kullanıcı adı bilgisi boş olamaz!");
            RuleFor(p => p.username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");

            RuleFor(p => p.password).NotEmpty().WithMessage("Parola bilgisi boş olamaz!");
            RuleFor(p => p.password).NotNull().WithMessage("Parola bilgisi boş olamaz!");

            RuleFor(p => p.password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük karakter içermelidir.");
            RuleFor(p => p.password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük karakter içermelidir.");
            RuleFor(p => p.password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir.");
            RuleFor(p => p.password).Matches("[^a-zA-z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir.");
        }
    }
}
