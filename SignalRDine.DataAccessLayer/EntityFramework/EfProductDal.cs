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

	public int GetProductCount()
	{
        return _context.Products.Count();
	}

	public List<Product> GetProductsWithCategories()
    {
        var values = _context.Products.Include(x => x.Category).ToList();
        return values;
    }

	public int ProductCountByCategoryNameDrink()
	{
		return _context.Products.Count(x => x.Category.CategoryName == "İçecek");
		//return _context.Products.Where(x=>x.CategoryID==(_context.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=>z.CategoryID).FirstOrDefault())).Count();
	}

	public int ProductCountByCategoryNameHamburger()
	{
		return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
	}

	public string ProductNameByMaxPrice()
	{
		return _context.Products.OrderByDescending(x => x.Price).Select(y => y.ProductName).FirstOrDefault();
		//return _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
	}

	public string ProductNameByMinPrice()
	{
		//return _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		return _context.Products.OrderBy(x => x.Price).Select(y => y.ProductName).FirstOrDefault();
	}

	public decimal ProductPriceAvg()
	{
		return _context.Products.Average(x => x.Price);
	}

	public decimal ProductAvgPriceByHamburger()
	{
		return _context.Products
		.Where(x => x.Category.CategoryName == "Hamburger")
		.Average(c => c.Price);

		//return _context.Products
		//	.Where(x=>x.CategoryID==(_context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(c=>c.Price);
	}

    public decimal ProductPriceBySteakBurger()
    {
        return _context.Products.Where(x=>x.ProductName == "Steak Burger").Select(y=>y.Price).FirstOrDefault();
    }

    public decimal TotalPriceByDrinkCategory()
    {
       int id=_context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryID).FirstOrDefault();
		return _context.Products.Where(x=>x.CategoryID==id).Sum(y=>y.Price);
    }

    public decimal TotalPriceBySaladCategory()
    {
		int id= _context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
		return _context.Products.Where(x=>x.CategoryID==id).Sum(y=>y.Price);
    }

    public List<Product> GetLast9Products()
    {
        return _context.Products.Take(9).ToList();
    }

    public decimal TotalProductPrice()
    {
        var total = _context.Products.Sum(x => x.Price);
        return total;
    }
}