using InventoryManagementInterfaces;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using InventoryManagementBll.Concrete;
using ICompanyAddressesServices.concrete.EntityFramework;

namespace InventoryManagementWcfServiceIISHost
{
   
    public class Company : ICompanyService
    {
        private CompanyManager _companyManeger = new CompanyManager(new EfCompanyDal());
        public bool Add(InventoryManagementEntity.Company company)
        {
         return _companyManeger.Add(company);
        }

        public void Delete(int companyId)
        {
            _companyManeger.Delete(companyId);
        }

        public InventoryManagementEntity.Company Get(int companyId)
        {
           return _companyManeger.Get(companyId);
        }

        public List<InventoryManagementEntity.Company> GetAll()
        {
            return _companyManeger.GetAll();
        }

        public void Update(InventoryManagementEntity.Company company)
        {
            _companyManeger.Update(company);
        }
    }
}
