using Microsoft.EntityFrameworkCore;
using SignalRDine.DataAccessLayer.Abstract;
using SignalRDine.DataAccessLayer.Concrete;
using SignalRDine.DataAccessLayer.Repositories;
using SignalRDine.EntityLayer.Entities;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    private readonly SignalRDineContext _context; 

    public EfProductDal(SignalRDineContext context) : base(context)
    {
        _context = context; 
    }

    public List<Product> GetProductsWithCategories()
    {
        var values = _context.Products.Include(x => x.Category).ToList();
        return values;
    }
}