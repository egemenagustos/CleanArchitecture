using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Araç adı boş olamaz!");
            RuleFor(p => p.name).NotNull().WithMessage("Araç adı boş olamaz!");
            RuleFor(p => p.name).MinimumLength(3).WithMessage("Araç adı en az 3 karakter olmalıdır!");
            RuleFor(p => p.model).NotEmpty().WithMessage("Araç modeli boş olamaz!");
            RuleFor(p => p.model).NotNull().WithMessage("Araç modeli boş olamaz!");
            RuleFor(p => p.model).MinimumLength(3).WithMessage("Araç modeli en az 3 karakter olmalıdır!");

            RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Araç motor gücü boş olamaz!");
            RuleFor(p => p.EnginePower).NotNull().WithMessage("Araç motor gücü  boş olamaz!");
            RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Araç motor gücü 0'dan büyük olmalıdır.");
        }
    }
}
