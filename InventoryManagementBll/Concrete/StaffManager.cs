using ICompanyAddressesServices.Abstrack;
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
            /*Username kontrol yapılacak*/
            _staffDal.Add(staff);
        }

        public void Delete(int Id)
        {
            _staffDal.Delete(Id);
        }

        public Staff Get(int Id, int companyId)
        {
            return _staffDal.Get(Id,companyId);
        }

        public List<Staff> GetAll()
        {
           return _staffDal.GetAll();
        }

        public List<Staff> GetAllById(int CompanyId)
        {
            return _staffDal.GetAllById(CompanyId);
        }

        public void Update(Staff staff)
        {  /*Username kontrol yapılacak*/
            _staffDal.Update(staff);
        }
    }
}
