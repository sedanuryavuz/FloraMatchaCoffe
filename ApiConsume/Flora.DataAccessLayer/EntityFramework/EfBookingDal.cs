using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new Context();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new Context();
            var values = context.Bookings.Find(id);
            if (values != null)
            {
                values.Description = "Rezervasyon İptal Edildi";
                context.SaveChanges();
            }
        }
    }
}