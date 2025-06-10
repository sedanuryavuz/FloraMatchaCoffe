using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Concrete
{
    public class BasketManager:IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TInsert(Basket entity)
        {
            _basketDal.Insert(entity);
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
