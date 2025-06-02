using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(Context context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new Context();
            return context.Categories!.Where(c => c.CategoryStatus==true).Count();
        }

        public int CategoryCount()
        {
            using var context = new Context();
            return context.Categories!.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new Context();
            return context.Categories!.Where(c => c.CategoryStatus == false).Count();
        }
    }
}
