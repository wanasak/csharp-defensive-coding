using System;
using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public string Category { get; set; }
        public List<Discount> Discounts { get; set; }
        public Discount ProductDiscount { get; set; }
        public string ProductName { get; set; }
        public string Reason { get; set; }
    }
}
