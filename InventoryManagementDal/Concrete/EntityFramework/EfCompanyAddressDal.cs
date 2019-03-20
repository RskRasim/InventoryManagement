using ICompanyAddressesServices.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Concrete.EntityFramework
{
   public class EfCompanyAddressDal : ICompanyAddressesDal
    {
        InventoryManagementContext _contextDb;

        public EfCompanyAddressDal()
        {
            _contextDb = new InventoryManagementContext();
        }


        public void Add(CompanyAddress companyAddress)
        {
            _contextDb.CompanyAddresses.Add(companyAddress);
            _contextDb.SaveChanges();
        }

        public void Delete(int CompanyId)
        {
            _contextDb.CompanyAddresses.Remove(_contextDb.CompanyAddresses.FirstOrDefault(s => s.CompanyId == CompanyId));
            _contextDb.SaveChanges();
        }

        public CompanyAddress Get(int CompanyId)
        {
            return _contextDb.CompanyAddresses.FirstOrDefault(s =>  s.CompanyId == CompanyId);
        }

     

        public List<CompanyAddress> GetAll()
        {
            return _contextDb.CompanyAddresses.ToList();
        }

        public void Update(CompanyAddress companyAddress)
        {
            CompanyAddress UpdateCompanyAddress = _contextDb.CompanyAddresses.FirstOrDefault(s => s.CompanyId == companyAddress.CompanyId);

            UpdateCompanyAddress.Address = companyAddress.Address;

            _contextDb.SaveChanges();
        }
    }
}
