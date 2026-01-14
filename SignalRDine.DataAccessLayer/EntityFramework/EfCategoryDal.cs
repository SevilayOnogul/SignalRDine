using Microsoft.EntityFrameworkCore;
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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
		private readonly SignalRDineContext _context;

		public EfCategoryDal(SignalRDineContext context) : base(context)
        {
			_context = context;
        }

		public int ActiveCategoryCount()
		{
			return _context.Categories.Where(x=>x.CategoryStatus==true).Count();
		}

		public int CategoryCount()
		{
			return _context.Categories.Count();
		}

		public int PassiveCategoryCount()
		{
			return _context.Categories.Where(x=>x.CategoryStatus==false).Count();	
		}
	}
}
