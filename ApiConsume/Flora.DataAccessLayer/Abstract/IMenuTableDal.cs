using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.Abstract
{
    public interface IMenuTableDal:IGenericDal<MenuTable>
    {
        int MenuTableCount();
        void ChangeMenuTableStatusToTrue(int id);
        void ChangeMenuTableStatusToFalse(int id);
    }
}
