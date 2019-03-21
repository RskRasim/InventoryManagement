using ICompanyAddressesServices.Abstrack;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.concrete.EntityFramework
{
    public class EfStoreDal : IStoreDal
    {
        private InventoryManagementContext _contexDb;

        public EfStoreDal()
        {
            _contexDb   = new InventoryManagementContext();
        }

        public void Add(Store store)
        {
            _contexDb.Stores.Add(store);
            _contexDb.SaveChanges();
                
                
        }

        public void Delete(int storeId)
        {
            _contexDb.Stores.Remove(_contexDb.Stores.FirstOrDefault(s => s.Id == storeId));
        }

        public Store Get(int storeId)
        {
          return  _contexDb.Stores.FirstOrDefault(s => s.Id == storeId);
        }

        public List<Store> GetAll()
        {
            return _contexDb.Stores.ToList();
        }

        public List<Store> GetAllById(int CompanyId)
        {
          return  _contexDb.Stores.Where(s => s.CompanyId == CompanyId).ToList();
        }

        public void Update(Store store)
        {
           Store storeUp = _contexDb.Stores.FirstOrDefault(s => s.Id == store.Id);

            storeUp.Name = store.Name;
            storeUp.Address = store.Address;
            _contexDb.SaveChanges();
        }
    }
}
