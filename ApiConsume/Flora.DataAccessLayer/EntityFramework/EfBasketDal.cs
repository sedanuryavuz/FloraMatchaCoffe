using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new Context();
            var values = context.Baskets!.Where(x=>x.MenuTableId== id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}
