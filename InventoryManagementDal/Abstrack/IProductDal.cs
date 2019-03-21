using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Abstrack
{
    public interface IProductDal
    {
        List<Product> GetAll();
        List<Product> GetAllById(int CompanyId);
        Product Get(int productId);
        void Add(Product product);
        void Delete(int Id);
        void Update(Product product);
     
    }
}
