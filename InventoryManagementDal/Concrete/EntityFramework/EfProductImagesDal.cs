using ICompanyAddressesServices.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Concrete.EntityFramework
{
    public class EfProductImagesDal : IProductImagesDal
    {
        private InventoryManagementContext _contextDb;

        public EfProductImagesDal()
        {
            _contextDb = new InventoryManagementContext();
        }
      

        public void Add(ProductImage productImg)
        {
            _contextDb.ProductImages.Add(productImg);
            _contextDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            _contextDb.ProductImages.Remove(_contextDb.ProductImages.FirstOrDefault(s => s.Id == Id));
            _contextDb.SaveChanges();
        }

        public List<ProductImage> GetAll()
        {
           return _contextDb.ProductImages.ToList();
        }

        public ProductImage Get(int Id)
        {
            return _contextDb.ProductImages.FirstOrDefault(s => s.Id == Id);
        }

        public void Update(ProductImage productImg)
        {
          ProductImage productImgUp =  _contextDb.ProductImages.FirstOrDefault(s => s.Id == productImg.Id);

            productImgUp.ImgFolder = productImg.ImgFolder;

            _contextDb.SaveChanges();

        }


    }
}
