using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Abstrack
{
    public interface ICompanyDal
    {

        List<Company> GetAll();

        Company Get(int CompanyId);

        void Add(Company company);

        void Delete(int CompanyId);

        void Update(Company company);


    }
}
