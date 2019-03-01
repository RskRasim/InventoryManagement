using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
   public interface IMenuService
    {

        List<Menu> GetAll();

        void Add(Menu menu);

        void Delete(int Id);

    }
}
