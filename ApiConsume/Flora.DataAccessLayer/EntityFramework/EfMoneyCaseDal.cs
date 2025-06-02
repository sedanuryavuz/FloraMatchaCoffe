using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal:GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(Context context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new Context();
            return context.MoneyCases!.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
