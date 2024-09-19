using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Models
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = default;
        public string Color { get; set; } = default;
        public Decimal Price { get; set; } = default;
        public int ProductId { get; set; } = default;
        public string ProductName { get; set; } = default;
    }
}
