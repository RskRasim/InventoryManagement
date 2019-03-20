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
   public interface ICompanyAddressService
    {
        [OperationContract]
        void Add(CompanyAddress companyAddress);
        [OperationContract]
        void Delete(int CompanyId);
        [OperationContract]
        void Update(CompanyAddress companyAddress);
        [OperationContract]
        List<CompanyAddress> GetAll();
        [OperationContract]
        CompanyAddress Get(int CompanyId);
    }
}
