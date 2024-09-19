﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        //public Product Product { get; set; }
        public Customer Customer { get; set; }
    }

}
