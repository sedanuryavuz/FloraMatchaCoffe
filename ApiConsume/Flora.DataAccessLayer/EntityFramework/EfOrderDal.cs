using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new Context();
            return context.Orders!.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderTotalPrice()
        {
            using var context = new Context();
            var lastOrder = context.Orders!.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
            return lastOrder;
        }

        public decimal TodayTotalPrice()
        {
            using var context = new Context();
            return 0;
        }

        public int TotalOrderCount()
        {
            using var context = new Context();
            return context.Orders!.Count();
        }
    }
}
