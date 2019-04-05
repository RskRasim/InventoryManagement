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
       
        List<Staff> GetAllById(int companyId);
        Staff Get(int Id,int companyId);
        void Add(Staff staff);
        int Delete(int Id, int companyId);
        void Update(Staff staff);

    }
}
