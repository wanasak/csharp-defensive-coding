using Models;
using Services;
using System.Collections.Generic;
using Utilities;
using Xunit;

namespace testing
{
    public class DiscountTest
    {
        [Fact]
        public void FindDiscount_WhenListIsNull_ShouldReturNull()
        {
            // Arrange
            List<Discount>? discounts = null;
            var discountName = "40% off";
            Discount? expected = null;
            var discountService = new DiscountService();

            // Act
            var actual = discountService.FindDiscount(discounts, discountName);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindDiscountWithException_WhenNotFound_ShouldReturnNotFound()
        {
            // Arrange
            List<Discount>? discounts = new List<Discount>();
            var discountName = "40% off";
            var discountService = new DiscountService();

            // Act
            var ex = Assert.Throws<DiscountNotFoundException>(() => discountService.FindDiscountWithException(discounts, discountName));

            // Assert
            Assert.Equal("Discount not found", ex.Message);
        }

        [Fact]
        public void FindDiscountWithTuple_WhenListIsNull_ShouldReturnNull()
        {
            // Arrange
            List<Discount>? discounts = null;
            var discountName = "40% off";
            (Discount? discount, string? message) expected = (discount: null, message: "No discounts found");
            var discountService = new DiscountService();

            // Act
            var actual = discountService.FindDiscountWithTuple(discounts, discountName);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
