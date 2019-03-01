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
    public class MenuManager : IMenuService
    {
      private IMenuDal menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            this.menuDal = menuDal;
        }

        public void Add(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAll()
        {
            return menuDal.GetAll();
        }
    }
}
