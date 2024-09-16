using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Commands.Validators
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Product.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .Length(3, 100).WithMessage("Product name must be between 3 and 100 characters");

            RuleFor(x => x.Product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
