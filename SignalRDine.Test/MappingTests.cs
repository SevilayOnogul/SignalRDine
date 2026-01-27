using AutoMapper;
using SignalRDine.DtoLayer.ProductDto; 
using SignalRDine.EntityLayer.Entities;
using SignalRDine.Api.Mapping; 
using Xunit;
using SignalRDine.DtoLayer.NotificationDto;

namespace SignalRDine.Test
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(ProductMapping).Assembly);
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Product_To_ResultProductDto_Should_Map_Values()
        {
            var product = new Product
            {
                ProductName = "Hamburger",
                Price = 250,
                ImageUrl = "test.jpg"
            };

            var result = _mapper.Map<ResultProductDto>(product);

            Assert.Equal(product.ProductName, result.ProductName);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.ImageUrl, result.ImageUrl);
        }

        [Fact]
        public void Notification_To_ResultNotificationDto_Should_Map_Values()
        {
            var notification = new Notification
            {
                NotificationID = 1,
                Description = "Yeni bir siparişiniz var!",
                Type = "Sipariş",
                Icon = "shopping-cart",
                Date = DateTime.Now,
                Status = false
            };

            var result = _mapper.Map<ResultNotificationDto>(notification);

            Assert.Equal(notification.Description, result.Description);
            Assert.Equal(notification.Type, result.Type);
            Assert.Equal(notification.Status, result.Status);
        }
    }
}