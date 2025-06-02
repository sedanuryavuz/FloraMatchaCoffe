using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IMoneyCaseService:IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();

    }
}
