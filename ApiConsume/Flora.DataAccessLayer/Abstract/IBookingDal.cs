using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);
    }
}
