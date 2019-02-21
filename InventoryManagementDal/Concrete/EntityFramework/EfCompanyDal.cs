using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.concrete.EntityFramework
{
    public class EfCompanyDal : ICompanyDal
    {
        private InventoryManagementContext _contexDb = new InventoryManagementContext();

        public void Add(Company company)
        {
            _contexDb.Company.Add(company);
            _contexDb.SaveChanges();
        }

        public void Delete(int CompanyId)
        {
            _contexDb.Company.Remove(_contexDb.Company.FirstOrDefault(s => s.CompanyId == CompanyId));
            _contexDb.SaveChanges();
        }

        public Company Get(int CompanyId)
        {
           return _contexDb.Company.FirstOrDefault(s => s.CompanyId == CompanyId);
        }

        public List<Company> GetAll()
        {
          return  _contexDb.Company.ToList();
        }

        public void Update(Company company)
        {
          Company  UpCompany = _contexDb.Company.FirstOrDefault(s => s.CompanyId == company.CompanyId);

            UpCompany.Name = company.Name;
            UpCompany.TaxNumber = company.TaxNumber;
            UpCompany.Password = company.Password;
            _contexDb.SaveChanges();
        }
    }
}
