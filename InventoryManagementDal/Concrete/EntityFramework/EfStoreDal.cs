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
            throw new NotImplementedException();
        }

        public Store Get(int storeId)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
