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
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		private readonly SignalRDineContext _context;
		public EfMoneyCaseDal(SignalRDineContext context) : base(context)
		{
			_context = context;
		}

		public decimal TotalMoneyCaseAmount()
		{
			return _context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
		}
	}
}
