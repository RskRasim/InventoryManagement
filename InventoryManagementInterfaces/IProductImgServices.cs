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
   public interface IProductImgServices
    {
        [OperationContract]
        void Add(ProductImg productImg);
        [OperationContract]
        void Delete(int Id);
        [OperationContract]
        void Update(ProductImg productImg);
        [OperationContract]
        List<ProductImg> GetAll();
        [OperationContract]
        ProductImg Get(int Id);
    }
}
