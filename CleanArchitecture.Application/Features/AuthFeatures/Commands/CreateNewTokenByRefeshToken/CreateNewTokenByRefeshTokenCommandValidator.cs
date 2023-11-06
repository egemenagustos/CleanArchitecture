using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken
{
    public sealed class CreateNewTokenByRefeshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefeshTokenCommand>
    {
        public CreateNewTokenByRefeshTokenCommandValidator()
        {
            RuleFor(p => p.userId).NotEmpty().WithMessage("User bilgisi boş olamaz!");
            RuleFor(p => p.userId).NotNull().WithMessage("User bilgisi boş olamaz!");
            RuleFor(p => p.refreshToken).NotEmpty().WithMessage("RefreshToken bilgisi boş olamaz!");
            RuleFor(p => p.refreshToken).NotNull().WithMessage("RefreshToken bilgisi boş olamaz!");
        }
    }
}
