using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Abstract
{
    public interface IMenuTableService:IGenericService<MenuTable>
    {
        int TMenuTableCount();
        void TChangeMenuTableStatusToTrue(int id);
        void TChangeMenuTableStatusToFalse(int id);
    }
}
