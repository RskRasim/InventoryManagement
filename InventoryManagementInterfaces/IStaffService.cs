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
   public interface IStaffService
    {
        [OperationContract]
        void Add(Staff staff);
        [OperationContract]
        int Delete(int Id, int companyId);
        [OperationContract]
        void Update(Staff staff);
        [OperationContract]
        List<Staff> GetAll();
        [OperationContract]
        List<Staff> GetAllById(int companyId);
        [OperationContract]
        Staff Get(int Id,int companyId);
        [OperationContract]
        int IsActivet(int Id, int CompanyId);





    }
}
