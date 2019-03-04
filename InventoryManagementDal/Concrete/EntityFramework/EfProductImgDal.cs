using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    public class EfProductImgDal : IProductImgDal
    {
        private InventoryManagementContext _contextDb;

        public EfProductImgDal(InventoryManagementContext contextDb)
        {
            _contextDb = contextDb;
        }

        public void Add(ProductImg productImg)
        {
            _contextDb.ProductImg.Add(productImg);
            _contextDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            _contextDb.ProductImg.Remove(_contextDb.ProductImg.FirstOrDefault(s => s.Id == Id));
            _contextDb.SaveChanges();
        }

        public List<ProductImg> GetAll()
        {
           return _contextDb.ProductImg.ToList();
        }

        public ProductImg Get(int Id)
        {
            return _contextDb.ProductImg.FirstOrDefault(s => s.Id == Id);
        }

        public void Update(ProductImg productImg)
        {
          ProductImg productImgUp =  _contextDb.ProductImg.FirstOrDefault(s => s.Id == productImg.Id);

            productImgUp.Img = productImg.Img;

            _contextDb.SaveChanges();

        }


    }
}
