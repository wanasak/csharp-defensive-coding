using Models;
using Services;
using System;
using Xunit;

namespace testing
{
    public class ProductTest
    {
        [Fact]
        public void CalculateMargin_WhenValidCost50PercentOfPrice_ShouldReturn50()
        {
            // Arrange
            string cost = "50";
            string price = "100";
            decimal expected = 50;
            var productServie = new ProductService();

            // Act
            decimal actual = productServie.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostOneThirdOfPrice_ShouldReturnTo33()
        {
            // Arrange
            string cost = "100";
            string price = "150";
            decimal expected = 33;
            var productServie = new ProductService();

            // Act
            decimal actual = productServie.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidPriceIsEmpty_ShouldGenerateError()
        {
            // Arrange
            string cost = "50";
            string price = "";
            var productServie = new ProductService();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => productServie.CalculateMargin(cost, price));
            Assert.Equal("Please enter the price (Parameter 'price')", ex.Message);
        }

        [Fact]
        public void ValidateEffectiveDate_WhenDateIsNull_ShouldReturnFalse()
        {
            // Arrange
            DateTime? effectiveDate = null;
            var expected = false;
            var productServie = new ProductService();

            // Act
            var actual = productServie.ValidateEffectiveDate(effectiveDate);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
