using Microsoft.EntityFrameworkCore;
using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.DataAccessLayer.Repositories;
using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDine.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRDineContext _context;
        public EfBasketDal(SignalRDineContext context) : base(context)
        {
            _context = context;
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            return (_context.Baskets.Where(x => x.MenuTableID == id).Include(y => y.Product).ToList());
        }

        public List<ResultBasketListWithProducts> GetBasketListByMenuTableWithProductName(int id)
        {
            return _context.Baskets
    .Include(x => x.Product)
    .Where(y => y.MenuTableID == id)
    .Select(z => new ResultBasketListWithProducts
    {
        BasketID = z.BasketID,
        Count = z.Count,
        MenuTableID = z.MenuTableID,
        Price = z.Price,
        ProductID = z.ProductID,
        TotalPrice = z.TotalPrice,
        ProductName = z.Product.ProductName
    })
    .ToList();
        }
    }
}
