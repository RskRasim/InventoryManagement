using InventoryManagementEntity;
using System.ServiceModel;

namespace InventoryManagementInterfaces
{
    [ServiceContract]
    public interface IAuthenticationService
    {


        [OperationContract]
        Company AuthenticationCompany(Company user);
        [OperationContract]
        Staff AuthenticationStaff(Staff user);

    }
}