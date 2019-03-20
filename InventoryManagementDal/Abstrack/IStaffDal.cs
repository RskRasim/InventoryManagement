using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Abstrack
{
    public interface IStaffDal
    {
        List<Staff> GetAll();
       
        List<Staff> GetAllById(int CompanyId);
        Staff Get(int Id);
        void Add(Staff staff);
        void Delete(int Id);
        void Update(Staff staff);

    }
}
