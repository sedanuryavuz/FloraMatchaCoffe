using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.DtoLayer.ProductDto;
using Flora.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new Context();
            var values = context.Products!
                .Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new Context();
            return context.Products!.Count();
        }

        public int ProductCountByCategoryDessert()
        {
            using var context = new Context();
            return context.Products!
                .Where(x => x.CategoryId == (context.Categories!.Where
                (y => y.CategoryName == "İçecek").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryDrink()
        {
            using var context = new Context();
            return context.Products!
                .Where(x => x.CategoryId == (context.Categories!.Where
                (y => y.CategoryName == "Tatlı").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new Context();
            return context.Products!
                .Where(x => x.Price == (context.Products!.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault()!;
        }

        public string ProductNameByMinPrice()
        {
            using var context = new Context();
            return context.Products!
                .Where(x => x.Price == (context.Products!.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault()!;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new Context();
            return context.Products!
                .Average(x => x.Price);
        }

        public decimal ProductPriceByCategoryDrink()
        {
            using var context = new Context();
            return context.Products!
                .Where(x => x.CategoryId == (context.Categories!.Where
                (y => y.CategoryName == "İçecek").Select(z => z.CategoryId).FirstOrDefault())).Average(z => z.Price);
        }
    }
}
