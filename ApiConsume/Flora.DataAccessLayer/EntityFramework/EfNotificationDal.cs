using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(Context context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationsByFalse()
        {
            using var context = new Context();
            return context.Notifications!.Where(x=>x.Status==false).ToList();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new Context();
            var value = context.Notifications!.Find(id);
            value!.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new Context();
            var value = context.Notifications?.Find(id);
            value!.Status=true;
            context.SaveChanges();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new Context();
            return context.Notifications!.Where(x=>x.Status==false).Count();
        }
    }
}
