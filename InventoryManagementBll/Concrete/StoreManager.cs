using ICompanyAddressesServices.Abstrack;
using InventoryManagementEntity;
using InventoryManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBll.Concrete
{
    public class StoreManager : IStoreService
    {
        private IStoreDal _storeDal;

        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }

        public void Add(Store store)
        {
            _storeDal.Add(store);
        }

        public void Delete(int storeId)
        {
            _storeDal.Delete(storeId);
        }

        public Store Get(int storeId)
        {
            return _storeDal.Get(storeId);
        }

        public List<Store> GetAll()
        {
           return _storeDal.GetAll();
        }

        public void Update(Store store)
        {
            _storeDal.Update(store);
        }
    }
}
