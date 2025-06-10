using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(Context context) : base(context)
        {
            
        }
    }
}
