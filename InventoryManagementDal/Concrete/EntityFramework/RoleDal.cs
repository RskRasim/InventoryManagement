using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    public class RoleDal : IRoleDal
    {
        private InventoryManagementContext _contexDb;
        public RoleDal()
        {
            _contexDb = new InventoryManagementContext();
        }
        public void Add(Role role)
        {
            _contexDb.Roles.Add(role);
        }

        public void Delete(int Id, int CompanyId)
        {
            _contexDb.Roles.Remove(_contexDb.Roles.FirstOrDefault(s=> s.Id == Id && s.CompanyId == CompanyId));
        }

        public Role GetRole(string Username)
        {
          return  _contexDb.Roles.FirstOrDefault(s => s.UserName == Username);
        }
    }
}
