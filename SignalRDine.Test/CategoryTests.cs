using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Test
{
    public class CategoryTests
    {
        [Fact]
        public void CategoryName_Should_Not_Be_Empty()
        {
            var category = new Category();
            category.CategoryName = "Tatlýlar";

            Assert.NotNull(category.CategoryName);
            Assert.NotEmpty(category.CategoryName);
        }

        [Fact]
        public void Category_Should_Have_Products_Relation_Correctly()
        {
            var category = new Category()
            {
                CategoryName = "Tatlýlar",
                CategoryStatus = true,
                Products = new List<Product>
                {
                    new Product{ProductName="Sütlaç",Price=80,ProductStatus=true},
                    new Product{ProductName="Baklava",Price=150,ProductStatus=true},
                }
            };

            var productCount=category.Products.Count();

            Assert.Equal(2,productCount);
            Assert.Contains(category.Products, x => x.ProductName == "Sütlaç");
        }

        [Fact]
        public void Should_Not_Allow_Duplicate_Category_Names()
        {
            var categories = new List<Category>()
            {
                new Category{CategoryName="Ýçecekler"}
            };

            var newCategory = new Category { CategoryName = "Ýçecekler" };

            bool exists=categories.Any(x=>x.CategoryName==newCategory.CategoryName);

            Assert.True(exists, "Ayný isimde kategori zaten mevcut!");
        }

    }
}