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
    public class ProductImgManager : IProductImgServices
    {
       private IProductImgDal productDal;

        public ProductImgManager(IProductImgDal productDal)
        {
            this.productDal = productDal;
        }

        public void Add(ProductImg productImg)
        {
            productDal.Add(productImg);
        }

        public void Delete(int Id)
        {
            productDal.Delete(Id);

        }

        public List<ProductImg> GetAll()
        {
            return productDal.GetAll();
        }

        public ProductImg Get(int Id)
        {
           return productDal.Get(Id);
        }

        public void Update(ProductImg productImg)
        {
            productDal.Update(productImg);
        }
    }
}
