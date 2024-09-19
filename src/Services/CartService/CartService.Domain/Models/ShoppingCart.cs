﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart()
        {
            
        }

    }
}
