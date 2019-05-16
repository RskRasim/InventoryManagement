using ICompanyAddressesServices.Abstrack;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.concrete.EntityFramework
{
    public class EfCompanyDal : ICompanyDal
    {
        private InventoryManagementContext _contexDb;
        public EfCompanyDal()
        {
            _contexDb = new InventoryManagementContext();

        }
        public void Add(Company company)
        {
            _contexDb.Companies.Add(company);
            _contexDb.SaveChanges();
        }

        public void Delete(int companyId)
        {
            _contexDb.Companies.Remove(_contexDb.Companies.FirstOrDefault(s => s.Id == companyId));
            _contexDb.SaveChanges();
        }

        public Company Get(int companyId)
        {
           return _contexDb.Companies.FirstOrDefault(s => s.Id == companyId);
        }

        public List<Company> GetAll()
        {
            return _contexDb.Companies.ToList();
        }

        public Company GetTax(string TaxNumber)
        {
            return _contexDb.Companies.FirstOrDefault(s => s.TaxNumber == TaxNumber);
        }

        public void Update(Company company)
        {
          Company  UpCompany = _contexDb.Companies.FirstOrDefault(s => s.Id == company.Id);

            UpCompany.Name = company.Name;
            UpCompany.TaxNumber = company.TaxNumber;
            UpCompany.Password = company.Password;
            _contexDb.SaveChanges();
        }
    }
}
