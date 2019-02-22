using InventoryManagementDal.Abstrack;
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
        private IProductDal _productDal;

        public CompanyManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Company company)
        {
            throw new NotImplementedException();
        }

        public void Delete(int companyId)
        {
            throw new NotImplementedException();
        }

        public Company Get(int companyId)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
