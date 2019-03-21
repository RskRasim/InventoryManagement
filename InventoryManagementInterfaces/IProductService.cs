using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
    [ServiceContract]
   public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();
        [OperationContract]
        List<Product> GetAllById(int CompanyId);
        [OperationContract]
        Product Get(int productId);
        [OperationContract]
        void Add(Product product);
        [OperationContract]
        void Delete(int Id);
        [OperationContract]
        void Update(Product product);

    }
}
