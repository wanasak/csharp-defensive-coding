using Models;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class DiscountService
    {
        public Discount? FindDiscount(List<Discount>? discounts, string discountName)
        {
            if (discounts is null) return null;

            var foundDiscount = discounts.Find(x => x.DiscountName == discountName);

            return foundDiscount;
        }

        public Discount FindDiscountWithException(List<Discount> discounts, string name)
        {
            if (discounts is null) throw new ArgumentException("No discounts found");

            var foundDiscount = discounts.Find(x => x.DiscountName == name);

            if (foundDiscount is null) throw new DiscountNotFoundException("Discount not found");

            return foundDiscount;
        }

        public (Discount? discount, string? message) FindDiscountWithTuple(List<Discount>? discounts, string discountName)
        {
            if (discounts is null)
                return (discount: null, message: "No discounts found");

            var foundDiscount = discounts.Find(x => x.DiscountName == discountName);

            if (foundDiscount is null)
                return (discount: null, message: "Discount not found");

            return (discount: foundDiscount, message: null);
        }
    }
}
