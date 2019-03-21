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
    public interface IStoreService
    {
        [OperationContract]
        List<Store> GetAll();
        [OperationContract]
        List<Store> GetAllById(int CompanyId);
        [OperationContract]
        Store Get(int storeId);
        [OperationContract]
        void Add(Store store);
        [OperationContract]
        void Delete(int storeId);
        [OperationContract]
        void Update(Store store);


    }
}
