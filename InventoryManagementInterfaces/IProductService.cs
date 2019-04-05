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
        List<Product> GetAllById(int companyId);
        [OperationContract]
        Product Get(int productId ,int companyId);
        [OperationContract]
        void Add(Product product);
        [OperationContract]
        int Delete(int Id, int companyId);
        [OperationContract]
        void Update(Product product);

    }
}
