using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TBookingStatusApproved(int id);
        void TBookingStatusCancelled(int id);
    }
}
