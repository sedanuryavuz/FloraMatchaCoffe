using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(Context context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            using var context = new Context();
            var value = context.MenuTables!.Where(x => x.MenuTableId == id).FirstOrDefault();
            value!.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
           using var context = new Context();
            var value = context.MenuTables!.Where(x => x.MenuTableId == id).FirstOrDefault();
            value!.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
           using var context = new Context();
            return context.MenuTables!.Count();
        }
    }
}
