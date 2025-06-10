using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationsByFalse();
        void TNotificationStatusChangeToTrue(int id);
        void TNotificationStatusChangeToFalse(int id);
    }
}
