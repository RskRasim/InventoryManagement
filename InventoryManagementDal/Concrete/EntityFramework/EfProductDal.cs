
using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
       private InventoryManagementContext _contextDb = new InventoryManagementContext();

        public void Add(Product product)
        {
            _contextDb.Product.Add(product);
            _contextDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            _contextDb.Product.Remove(_contextDb.Product.FirstOrDefault(s => s.ProductId == Id));
            _contextDb.SaveChanges();
        }

        public Product Get(int productId)
        {
           return _contextDb.Product.FirstOrDefault(s => s.ProductId == productId);
        }

        public List<Product> GetAll()
        {
          return _contextDb.Product.ToList();
        }

        public void Update(Product product)
        {
           Product productUp = _contextDb.Product.FirstOrDefault(s => s.ProductId == product.ProductId);

            productUp.ProductName = product.ProductName;
            productUp.ShelfNumber = product.ShelfNumber;
            productUp.ProductCode = product.ProductCode;
            productUp.BarcodeCode = product.BarcodeCode;
            productUp.BarcodeCode2 = product.BarcodeCode2;
            productUp.Pieces = product.Pieces;
            productUp.MaxPieces = product.MaxPieces;
            productUp.MinPieces = product.MinPieces;
            productUp.StoreId = product.StoreId;

            _contextDb.SaveChanges();
        }
    }
}
