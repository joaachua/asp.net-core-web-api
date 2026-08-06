using FluentValidation;
using NmqPracticeApi.DTOs;

namespace NmqPracticeApi.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(product => product.Price)
            .GreaterThan(0);

        RuleFor(product => product.Stock)
            .GreaterThanOrEqualTo(0);
    }
}