﻿using FluentValidation;
using Shared.DTOs.Product;

namespace Shared.FluentValidators;

public class ProductCreationValidator : AbstractValidator<ProductForCreationDto>
{
    public ProductCreationValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is a required field.");
        RuleFor(x => x.Name).MaximumLength(30).WithMessage("Maximum length for Name is 30 characters.");
        RuleFor(x => x.Description).MaximumLength(300).WithMessage("Maximum length for Description is 300 characters.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        RuleFor(x => x.StockQuantity).GreaterThan(0).WithMessage("StockQuantity must be greater than 0.");
    }
}
