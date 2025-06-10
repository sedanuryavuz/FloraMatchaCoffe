using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Concrete
{
    internal class NotificationManager:INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> TGetAllNotificationsByFalse()
        {
            return _notificationDal.GetAllNotificationsByFalse();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void TInsert(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public void TNotificationStatusChangeToFalse(int id)
        {
            _notificationDal.NotificationStatusChangeToFalse(id);
        }

        public void TNotificationStatusChangeToTrue(int id)
        {
            _notificationDal.NotificationStatusChangeToTrue(id);
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
