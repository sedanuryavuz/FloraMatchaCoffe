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
    }
}
