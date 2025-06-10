using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(Context context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            using var context = new Context();
            var value = context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            using var context = new Context();
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            using var context = new Context();
            return context.Discounts.Where(x => x.Status == true).ToList();
        }
    }
}
