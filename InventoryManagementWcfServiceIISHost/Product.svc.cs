using InventoryManagementInterfaces;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InventoryManagementWcfServiceIISHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Product" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Product.svc or Product.svc.cs at the Solution Explorer and start debugging.
    public class Product : IProductService
    {
        public void Add(InventoryManagementEntity.Product product)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id, int companyId)
        {
            throw new NotImplementedException();
        }


        public InventoryManagementEntity.Product Get(int productId, int companyId)
        {
            throw new NotImplementedException();
        }

        public List<InventoryManagementEntity.Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<InventoryManagementEntity.Product> GetAllById(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public void Update(InventoryManagementEntity.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
