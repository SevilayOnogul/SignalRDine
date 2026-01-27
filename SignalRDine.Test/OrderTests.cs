using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.Test
{
    public class OrderTests
    {
        [Fact]
        public void Order_Total_Price_Should_Sum_Correctly()
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderDetails = new List<OrderDetail>
        {
            new OrderDetail { Count = 2, UnitPrice = 50 }, 
            new OrderDetail { Count = 1, UnitPrice = 75 }  
        }
            };

            decimal totalPrice = order.OrderDetails.Sum(x => x.Count * x.UnitPrice);

            Assert.Equal(175, totalPrice);
        }
    }
}
