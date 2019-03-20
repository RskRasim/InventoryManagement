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
        void Delete(int Id);
        [OperationContract]
        void Update(Staff staff);
        [OperationContract]
        List<Staff> GetAll();
        [OperationContract]
        List<Staff> GetAllById(int CompanyId);
        [OperationContract]
        Staff Get(int Id);




    }
}
