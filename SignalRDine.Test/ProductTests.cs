using SignalRDine.EntityLayer.Entities;
using Xunit;

namespace SignalRDine.Test
{
    public class ProductTests
    {
        [Fact]
        public void ProductPrice_Should_Be_Greater_Than_Zero()
        {
            var product = new Product();
            product.Price = 150.50m;

            Assert.True(product.Price > 0, "Ürün fiyatı 0'dan büyük olmalıdır!");
        }

        [Theory]
        [InlineData(100)]  
        [InlineData(50)] 
        [InlineData(10)]    
        public void ProductPrice_Check_Multiple_Values(decimal price)
        {
            var product = new Product { Price = price };
            Assert.True(product.Price > 0, $"Hatalı Fiyat: {price}. Fiyat sıfırdan büyük olmalı!");
        }
    }
}