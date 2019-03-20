using ICompanyAddressesServices.Abstrack;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System.Linq;

namespace ICompanyAddressesServices.Concrete
{
    public class EfAuthenticationDal : IAuthenticationDal
    {
        private InventoryManagementContext _contexDb;

        public EfAuthenticationDal()
        {
            _contexDb = new InventoryManagementContext();
        }

        public Company AuthenticationCompany(Company user)
        {
          return  _contexDb.Companies.FirstOrDefault(s => s.TaxNumber == user.TaxNumber && s.Password == user.Password && s.IsActive == true);
        }

        public Staff AuthenticationStaff(Staff user)
        {
            throw new System.NotImplementedException();
        }
    }
}