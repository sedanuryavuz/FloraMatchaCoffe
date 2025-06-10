using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);

    }
}
