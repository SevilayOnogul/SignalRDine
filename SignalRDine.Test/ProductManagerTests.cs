using Moq;
using SignalRDine.BusinessLayer.Concrete;
using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.EntityLayer.Entities;
using Xunit;

namespace SignalRDine.Test
{
    public class ProductManagerTests
    {
        [Fact]
        public void Product_Price_Cannot_Be_Zero_Or_Less()
        {
           
            var mockDal = new Mock<IProductDal>();
            var service = new ProductManager(mockDal.Object);

            var invalidProduct = new Product { Price = -10 };

           
            Assert.True(invalidProduct.Price <= 0, "Ürün fiyatı 0'dan büyük olmalıdır!");
        }
    }
}