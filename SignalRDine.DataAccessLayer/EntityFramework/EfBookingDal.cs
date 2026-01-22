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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRDineContext _context;
        public EfBookingDal(SignalRDineContext context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusApproved(int id)
        {
            var value=_context.Bookings.Find(id);
            value.Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();

        }

        public void BookingStatusCancelled(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();
        }

        public int GetBookingCount()
        {
            return _context.Bookings.Count();
        }
    }
}
