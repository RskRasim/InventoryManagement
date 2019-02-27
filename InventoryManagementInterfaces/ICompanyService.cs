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
   public interface ICompanyService
    {
        [OperationContract]
        List<Company> GetAll();
        [OperationContract]
        Company Get(int companyId);
        [OperationContract]
        void Add(Company company);
        [OperationContract]
        void Delete(int companyId);
        [OperationContract]
        void Update(Company company);

    }
}
