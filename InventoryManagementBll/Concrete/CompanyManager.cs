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
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void Add(Company company)
        {
            _companyDal.Add(company);
        }

        public void Delete(int companyId)
        {
            _companyDal.Delete(companyId);
        }

        public Company Get(int companyId)
        {
            return _companyDal.Get(companyId);
        }

        public List<Company> GetAll()
        {
           return _companyDal.GetAll();
        }

        public void Update(Company company)
        {
            _companyDal.Update(company);
        }
    }
}
