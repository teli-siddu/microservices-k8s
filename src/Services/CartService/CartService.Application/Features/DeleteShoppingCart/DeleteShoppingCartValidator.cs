using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Features.DeleteShoppingCart
{
    public class DeleteShoppingCartValidator:AbstractValidator<DeleteShoppingCartCommand>
    {
        public DeleteShoppingCartValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("User Name is required")
                .NotEmpty().WithMessage("User Name is required");
                
        }
    }
}
