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
	public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
	{

		public EfOrderDetailDal(SignalRDineContext context) : base(context)
		{
		}

	}
}
