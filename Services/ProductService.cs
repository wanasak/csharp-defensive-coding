using Models;
using System;
using Utilities;

namespace Services
{
    public class ProductService
    {
        public decimal CalculateMargin(string costInput, string priceInput)
        {
            // guard
            //if (string.IsNullOrWhiteSpace(costInput))
            //    throw new ArgumentException("Please enter the cost", "cost");
            //if (string.IsNullOrWhiteSpace(priceInput))
            //    throw new ArgumentException("Please enter the price", "price");

            Guard.ThrowIfNullOrEmpty(costInput, "Please enter the cost", "cost");
            Guard.ThrowIfNullOrEmpty(priceInput, "Please enter the price", "price");

            //var success = decimal.TryParse(costInput, out decimal cost);
            //if (!success || cost < 0) throw new ArgumentException("The cost must be a number 0 or greater", "cost");
            var cost = Guard.ThrowIfNotPositiveDecimal(costInput, "The cost must be a number 0 or greater", "cost");

            //success = decimal.TryParse(priceInput, out decimal price);
            //if (!success || price <= 0) throw new ArgumentException("The price must be a number and greater than 0", "price");
            var price = Guard.ThrowIfNotPositiveNonZeroDecimal(priceInput, "The price must be a number and greater than 0", "price");

            return Math.Round((price - cost) / price * 100M);
        }

        public bool ValidateEffectiveDate(DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue) return false;
            if (effectiveDate.Value < DateTime.Now.AddDays(7)) return false;

            return true;
        }

        public bool ValidateEffectiveDateWithRef(DateTime? effectiveDate, ref string validationMessage)
        {
            if (!effectiveDate.HasValue)
            {
                validationMessage = "Date has no value";
                return false;
            }
            if (effectiveDate.Value < DateTime.Now.AddDays(7))
            {
                validationMessage = "Date must be >= 7 days from today";
                return false;
            }
            return true;
        }

        public bool ValidateEffectiveDateWithOut(DateTime? effectiveDate, out string validationMessage)
        {
            validationMessage = "";
            if (!effectiveDate.HasValue)
            {
                validationMessage = "Date has no value";
                return false;
            }
            if (effectiveDate.Value < DateTime.Now.AddDays(7))
            {
                validationMessage = "Date must be >= 7 days from today";
                return false;
            }
            return true;
        }

        public (bool IsValid, string ValiadationMessage) ValidateEffectiveDateWithTuple(DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue)
                return (IsValid: false, ValiadationMessage: "Date has no value");
            if (effectiveDate.Value < DateTime.Now.AddDays(7))
                return (IsValid: false, ValiadationMessage: "Date must be >= 7 days from today");

            return (IsValid: true, ValiadationMessage: "");
        }

        public OperationResult ValidateEffectiveDateWithObject(DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue) return new OperationResult()
            {
                Success = false,
                Messagge = "Date has no value"
            };
            if (effectiveDate.Value < DateTime.Now.AddDays(7))
                return new OperationResult()
                {
                    Success = false,
                    Messagge = "Date must be >= 7 days from today"
                };

            return new OperationResult() { Success = true };
        }

        public decimal CalculateTotalDiscount(decimal price, Discount
             discount)
        {
            if (price <= 0) throw new ArgumentException("Please enter the price");
            if (discount?.PercentOff is null) throw new ArgumentException("Please specify a discount");

            var discountAmount = price * (discount.PercentOff.Value / 100);
            return discountAmount;
        }
    }
}
