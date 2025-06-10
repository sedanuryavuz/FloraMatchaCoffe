using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TChangeStatusToFalse(int id)
        {
            _discountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _discountDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> TGetAll()
        {
            return _discountDal.GetAll();
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> TGetListByStatusTrue()
        {
            return _discountDal.GetListByStatusTrue();
        }

        public void TInsert(Discount entity)
        {
            _discountDal.Insert(entity);
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
