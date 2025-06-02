using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public int TCategoryCount();
        int TActiveCategoryCount();
        int TPassiveCategoryCount();
    }
}
