using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.concrete.EntityFramework
{
    class EfStoreDal : IStoreDal
    {
        private InventoryManagementContext _contexDb = new InventoryManagementContext();
        public void Add(Store store)
        {
            _contexDb.Store.Add(store);
            _contexDb.SaveChanges();
                
                
        }

        public void Delete(int storeId)
        {
            _contexDb.Store.Remove(_contexDb.Store.FirstOrDefault(s => s.StoreId == storeId));
        }

        public Store Get(int storeId)
        {
          return  _contexDb.Store.FirstOrDefault(s => s.StoreId == storeId);
        }

        public List<Store> GetAll()
        {
            return _contexDb.Store.ToList();
        }

        public void Update(Store store)
        {
           Store storeUp = _contexDb.Store.FirstOrDefault(s => s.StoreId == store.StoreId);

            storeUp.Name = store.Name;
            storeUp.Address = store.Address;
            _contexDb.SaveChanges();
        }
    }
}
