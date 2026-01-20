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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly SignalRDineContext _context;
        public EfDiscountDal(SignalRDineContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            var value=_context.Discounts.Find(id);
            value.Status = false;
            _context.SaveChanges(); 
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = _context.Discounts.Find(id);
            value.Status = true;
            _context.SaveChanges();

        }

        public List<Discount> GetListByStatusTrue()
        {
            return _context.Discounts.Where(x=> x.Status).ToList(); 
        }
    }
}
