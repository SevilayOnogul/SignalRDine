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

        public void ChangeMenuTableStatusToFalse(int id)
        {
			var value=_context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
			value.Status = false;
			_context.SaveChanges();
			
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            var value=_context.MenuTables.Where(y=>y.MenuTableID==id).FirstOrDefault();
			value.Status=true; 
			_context.SaveChanges();
        }

        public int MenuTableCount()
		{
			return _context.MenuTables.Count();
		}
	}
}
