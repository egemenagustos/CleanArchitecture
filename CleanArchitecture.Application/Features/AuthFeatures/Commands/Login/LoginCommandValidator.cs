using CleanArchitecture.Application.Features.AuthFeatures.Login;
using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.userNameorEmail).NotEmpty().WithMessage("Kullanıcı adı veya mail bilgisi boş olamaz!");
            RuleFor(p => p.userNameorEmail).NotNull().WithMessage("Kullanıcı adı veya mail bilgisi boş olamaz!");
            RuleFor(p => p.userNameorEmail).MinimumLength(3).WithMessage("Kullanıcı adı veya mail en az 3 karakter olmalıdır.");

            RuleFor(p => p.password).NotEmpty().WithMessage("Parola bilgisi boş olamaz!");
            RuleFor(p => p.password).NotNull().WithMessage("Parola bilgisi boş olamaz!");

            RuleFor(p => p.password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük karakter içermelidir.");
            RuleFor(p => p.password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük karakter içermelidir.");
            RuleFor(p => p.password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir.");
            RuleFor(p => p.password).Matches("[^a-zA-z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir.");
        }
    }
}
