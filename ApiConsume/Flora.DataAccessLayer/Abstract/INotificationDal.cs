using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationsByFalse();
        void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);
    }
}
