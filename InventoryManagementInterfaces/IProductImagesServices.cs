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
   public interface IProductImagesServices
    {
        [OperationContract]
        void Add(ProductImage productImg);
        [OperationContract]
        void Delete(int Id);
        [OperationContract]
        void Update(ProductImage productImg);
        [OperationContract]
        List<ProductImage> GetAll();
        [OperationContract]
        ProductImage Get(int Id);
    }
}
