using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Abstrack
{
   public interface ICompanyAddressesDal
    {
        void Add(CompanyAddress companyAddress);

        void Delete(int CompanyId);

        void Update(CompanyAddress companyAddress);

        List<CompanyAddress> GetAll();

        CompanyAddress Get(int CompanyId);
    
    }
}
