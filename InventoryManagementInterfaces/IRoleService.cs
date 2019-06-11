using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
   public interface IRoleService
    {

        Role GetRole(string Username);

        void Add(Role role);

        void Delete(int Id, int CompanyId);
    }
}
