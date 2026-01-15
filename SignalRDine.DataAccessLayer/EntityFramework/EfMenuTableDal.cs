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
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		private readonly SignalRDineContext _context;
		public EfMenuTableDal(SignalRDineContext context) : base(context)
		{
			_context = context;
		}

		public int MenuTableCount()
		{
			return _context.MenuTables.Count();
		}
	}
}
