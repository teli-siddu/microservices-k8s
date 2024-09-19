using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }

}
