using CartService.Application.Features.AddCartItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Features.AddShoppingCart
{
    public class AddShoppingCartCommandValidator:AbstractValidator<AddShoppingCartCommand>
    {
        public AddShoppingCartCommandValidator()
        {
            RuleFor(x => x.Cart)
                .NotNull().WithMessage("")
                .Empty();
                
        }
    }
}
