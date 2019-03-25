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
  public interface ICustomerService
    {
        [OperationContract]
        void Add(Customer customer);
        [OperationContract]
        void Delete(int Id);
        [OperationContract]
        void Update(Customer customer);
        [OperationContract]
        Customer Get(int Id);
        [OperationContract]
        List<Customer> GetAll(int Id);
        [OperationContract]
        List<Customer> GetAllById(int companyId);
    }
}
