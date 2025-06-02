using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flora.BusinessLayer.Concrete
{
    public class OrderManager:IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }
        public List<Order> TGetAll()
        {
            return _orderDal.GetAll();
        }
        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }
        public void TInsert(Order entity)
        {
            _orderDal.Insert(entity);
        }

        public decimal TLastOrderTotalPrice()
        {
            return _orderDal.LastOrderTotalPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
