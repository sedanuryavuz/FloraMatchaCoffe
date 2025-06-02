using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        public int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}
