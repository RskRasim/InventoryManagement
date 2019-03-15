using InventoryManagementDal.Abstrack;
using InventoryManagementDal.Concrete.EntityFramework;
using InventoryManagementEntity;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementDal.concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private InventoryManagementContext _contextDb;

        public EfProductDal()
        {
            _contextDb = new InventoryManagementContext();
        }

        public void Add(Product product)
        {
            _contextDb.Products.Add(product);
            _contextDb.SaveChanges();
            
        }

        public void Delete(int Id)
        {
            /**************** ImageDelete *****************/
            _contextDb.ProductImages.Remove(_contextDb.ProductImages.FirstOrDefault(s => s.ProductId == Id));
            _contextDb.SaveChanges();
            /**/
            _contextDb.Products.Remove(_contextDb.Products.FirstOrDefault(s => s.Id == Id));
            _contextDb.SaveChanges();
        }

        public Product Get(int productId)
        {
           return _contextDb.Products.FirstOrDefault(s => s.Id == productId);
        }

        public List<Product> GetAll()
        {
          return _contextDb.Products.ToList();
        }

        public void Update(Product product)
        {
           Product productUp = _contextDb.Products.FirstOrDefault(s => s.Id == product.Id);

            productUp.ProductName = product.ProductName;
            productUp.ShelfNumber = product.ShelfNumber;
            productUp.ProductCode = product.ProductCode;
            productUp.BarcodeCode = product.BarcodeCode;
            productUp.BarcodeCode2 = product.BarcodeCode2;
            productUp.Pieces = product.Pieces;
            productUp.MaxPieces = product.MaxPieces;
            productUp.MinPieces = product.MinPieces;
            productUp.Store = product.Store;
            productUp.Price = product.Price;
            productUp.TaxRate = product.TaxRate;

            _contextDb.SaveChanges();
        }
   
    }
}
