
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
    public class CompanyAddressManager : ICompanyAddressService
    {
        private  ICompanyAddressesDal _companyAddressesDal;

        public CompanyAddressManager(ICompanyAddressesDal companyAddressesDal)
        {
            _companyAddressesDal = companyAddressesDal;
        }

        public void Add(CompanyAddress companyAddress)
        {
            _companyAddressesDal.Add(companyAddress);
        }

        public void Delete(int CompanyId)
        {
            _companyAddressesDal.Delete(CompanyId);
        }

        public CompanyAddress Get(int CompanyId)
        {
          return  _companyAddressesDal.Get(CompanyId);
        }

        public List<CompanyAddress> GetAll()
        {
            return _companyAddressesDal.GetAll();
        }

        public void Update(CompanyAddress companyAddress)
        {
            
                _companyAddressesDal.Update(companyAddress);
          
          
        }
    }
}
