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

        public EfStaffDal(InventoryManagementContext contexDb)
        {
            _contexDb = contexDb;
        }

        public void Add(Staff staff)
        {
            _contexDb.Staffs.Add(staff);
            _contexDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            _contexDb.Staffs.Remove(_contexDb.Staffs.FirstOrDefault(s => s.Id == Id));
            _contexDb.SaveChanges();
        }

        public Staff Get(int Id)
        {
          return _contexDb.Staffs.FirstOrDefault(s => s.Id == Id);
        }

        public List<Staff> GetAll()
        {
         return _contexDb.Staffs.ToList();
        }

        public void Update(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
