using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using InventoryManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBll.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(Role role)
        {
            _roleDal.Add(role);
        }

        public void Delete(int Id, int CompanyId)
        {
            _roleDal.Delete(Id, CompanyId);
        }

        public Role GetRole(string Username)
        {
            return _roleDal.GetRole(Username);
        }
    }
}
