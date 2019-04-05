using ICompanyAddressesServices.Abstrack;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System.Collections.Generic;
using System.Linq;

namespace ICompanyAddressesServices.concrete.EntityFramework
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

        public int Delete(int Id, int companyId)
        {
            /**************** ImageDelete *****************/
            ProductImage productImage = _contextDb.ProductImages.FirstOrDefault(s => s.ProductId == Id && s.Product.CompanyId == companyId);
            Product product = _contextDb.Products.FirstOrDefault(s => s.Id == Id && s.CompanyId == companyId);
            if (productImage != null)
            {
                _contextDb.ProductImages.Remove(productImage);
                _contextDb.Products.Remove(product);
                int events = _contextDb.SaveChanges();
                return events;
            }
            else
            {
                int events = 0;
                return events;
            }
    
            /**/
           
           
           
        }

       
        public Product Get(int productId, int companyId)
        {
            return _contextDb.Products.FirstOrDefault(s => s.Id == productId && s.CompanyId == companyId);
        }

        public List<Product> GetAll()
        {
          return _contextDb.Products.ToList();
        }

        public List<Product> GetAllById(int companyId)
        {
            return _contextDb.Products.Where(s => s.CompanyId == companyId).ToList();
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
