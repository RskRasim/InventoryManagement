using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    public class EfStaffDal : IStaffDal
    {
        private InventoryManagementContext _contexDb = new InventoryManagementContext();
       

        public void Add(Staff staff)
        {
            _contexDb.Staffs.Add(staff);
            _contexDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Staff Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Staff> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
