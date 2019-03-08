using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using InventoryManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBll.Concrete
{
  public  class StaffManager : IStaffService
    {
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void Add(Staff staff)
        {
            _staffDal.Add(staff);
        }

        public void Delete(int Id)
        {
            _staffDal.Delete(Id);
        }

        public Staff Get(int Id)
        {
          return  _staffDal.Get(Id);
        }

        public List<Staff> GetAll()
        {
           return _staffDal.GetAll();
        }

        public void Update(Staff staff)
        {
            _staffDal.Update(staff);
        }
    }
}
