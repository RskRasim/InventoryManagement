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
    public class ProductImagesManager : IProductImagesServices
    {
       private IProductImagesDal productImgDal;

        public ProductImagesManager(IProductImagesDal productImgDal)
        {
            this.productImgDal = productImgDal;
        }

        public void Add(ProductImage productImg)
        {
            productImgDal.Add(productImg);
        }

        public void Delete(int Id)
        {
            productImgDal.Delete(Id);

        }

        public List<ProductImage> GetAll()
        {
            return productImgDal.GetAll();
        }

        public ProductImage Get(int Id)
        {
           return productImgDal.Get(Id);
        }

        public void Update(ProductImage productImg)
        {
            productImgDal.Update(productImg);
        }
    }
}
