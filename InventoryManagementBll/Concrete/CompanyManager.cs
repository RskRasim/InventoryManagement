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

        public bool Add(Company company)
        {
            /*TaxNumber Kontrol yapılacak. Aynı TaxNuberden birtane olucak ve admin için */
            Company Com = _companyDal.GetTax(company.TaxNumber);
            if (Com == null)
            {
                _companyDal.Add(company);
                return true;
            }
            else
            {
                return false;
            }
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
            /*TaxNumber Kontrol yapılacak. Aynı TaxNuberden birtane olucak  */
            _companyDal.Update(company);
        }

      
    }
}
