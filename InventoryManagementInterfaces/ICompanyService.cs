using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
   public interface ICompanyService
    {

        List<Company> GetAll();

        Company Get(int companyId);

        void Add(Company company);

        void Delete(int companyId);

        void Update(Company company);

    }
}
