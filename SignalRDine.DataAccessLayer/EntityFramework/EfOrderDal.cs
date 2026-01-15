using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.DataAccessLayer.Repositories;
using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		private readonly SignalRDineContext _context;
		public EfOrderDal(SignalRDineContext context) : base(context)
		{
			_context = context;
		}

		public int ActiveOrderCount()
		{
			return _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			return _context.Orders.OrderByDescending(x => x.OrderID).Select(y => y.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			return _context.Orders
		.Where(x => x.OrderDate == DateTime.Today)
		.Sum(y => (decimal?)y.TotalPrice) ?? 0;
		}

		public int TotalOrderCount()
		{
			return _context.Orders.Count();
		}
	}
}
