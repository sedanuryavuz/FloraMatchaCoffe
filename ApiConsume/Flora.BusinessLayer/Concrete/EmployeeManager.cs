using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Abstract;
using Flora.EntityLayer.Entities;

namespace Flora.BusinessLayer.Concrete
{
    public class EmployeeManager:IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public void TDelete(Employee entity)
        {
            _employeeDal.Delete(entity);
        }
        public List<Employee> TGetAll()
        {
            return _employeeDal.GetAll();
        }
        public Employee TGetById(int id)
        {
            return _employeeDal.GetById(id);
        }
        public void TInsert(Employee entity)
        {
            _employeeDal.Insert(entity);
        }
        public void TUpdate(Employee entity)
        {
            _employeeDal.Update(entity);
        }
    }
}
