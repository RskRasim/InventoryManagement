using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    
    public class EfMenuDal : IMenuDal
    {
        private InventoryManagementContext _contextDb = new InventoryManagementContext();

        public EfMenuDal(InventoryManagementContext contextDb)
        {
            _contextDb = contextDb;
        }

        public void Add(Menu menu)
        {
            _contextDb.Menus.Add(menu);
        }

        public void Delete(int Id)
        {
            _contextDb.Menus.Remove(_contextDb.Menus.FirstOrDefault(s=> s.Id == Id));

        }

        public List<Menu> GetAll()
        {
            return _contextDb.Menus.ToList();
        }
    }
}
