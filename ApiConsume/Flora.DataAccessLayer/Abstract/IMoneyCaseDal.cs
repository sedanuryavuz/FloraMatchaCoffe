using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface IMoneyCaseDal:IGenericDal<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
