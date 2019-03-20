using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Abstrack
{
    public interface IProductImagesDal
    {
        void Add(ProductImage productImg);
        void Delete(int Id);
        void Update(ProductImage productImg);
        List<ProductImage> GetAll();
        ProductImage Get(int Id);


    }
}
