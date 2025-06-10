using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Concrete
{
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void TChangeMenuTableStatusToFalse(int id)
        {
            _menuTableDal.ChangeMenuTableStatusToFalse(id);
        }

        public void TChangeMenuTableStatusToTrue(int id)
        {
            _menuTableDal.ChangeMenuTableStatusToTrue(id);
        }

        public void TDelete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);
        }

        public List<MenuTable> TGetAll()
        {
            return _menuTableDal.GetAll();
        }

        public MenuTable TGetById(int id)
        {
            return _menuTableDal.GetById(id);
        }

        public void TInsert(MenuTable entity)
        {
            _menuTableDal.Insert(entity);
        }

        public int TMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            _menuTableDal.Update(entity);
        }
    }
}
