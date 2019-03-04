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
       private IProductImgDal productImgDal;

        public ProductImgManager(IProductImgDal productImgDal)
        {
            this.productImgDal = productImgDal;
        }

        public void Add(ProductImg productImg)
        {
            productImgDal.Add(productImg);
        }

        public void Delete(int Id)
        {
            productImgDal.Delete(Id);

        }

        public List<ProductImg> GetAll()
        {
            return productImgDal.GetAll();
        }

        public ProductImg Get(int Id)
        {
           return productImgDal.Get(Id);
        }

        public void Update(ProductImg productImg)
        {
            productImgDal.Update(productImg);
        }
    }
}
