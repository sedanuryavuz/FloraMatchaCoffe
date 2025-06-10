using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderTotalPrice();
        decimal TTodayTotalPrice();
    }
}
