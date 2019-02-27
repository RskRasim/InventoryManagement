using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    
    public class EfMenu : IMenu
    {
        private InventoryManagementContext _contextDb = new InventoryManagementContext();
        public void Add(Menu menu)
        {
            _contextDb.Menu.Add(menu);
        }

        public void Delete(int Id)
        {
            _contextDb.Menu.Remove(_contextDb.Menu.FirstOrDefault(s=> s.Id == Id));

        }

        public List<Menu> GetAll()
        {
            return _contextDb.Menu.ToList();
        }
    }
}
