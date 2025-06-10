using Flora.DataAccessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DataAccessLayer.Repositories;
using Flora.EntityLayer.Entities;

namespace Flora.DataAccessLayer.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public EfEmployeeDal(Context context) : base(context)
        {
        }
    }
}
