using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        private InventoryManagementContext _contexDb;

        public EfCustomerDal()
        {
            _contexDb = new InventoryManagementContext();
        }

        public void Add(Customer customer)
        {
            _contexDb.Customers.Add(customer);
            _contexDb.SaveChanges();
        }

        public void Delete(int Id)
        {
            _contexDb.Customers.Remove(_contexDb.Customers.FirstOrDefault(s => s.Id == Id));
            _contexDb.SaveChanges();
        }

        public Customer Get(int Id)
        {
           return _contexDb.Customers.FirstOrDefault(s => s.Id == Id);
        }

        public List<Customer> GetAll(int Id)
        {
            return _contexDb.Customers.ToList();
        }

        public List<Customer> GetAllById(int companyId)
        {
            return _contexDb.Customers.Where(s => s.CompanyId == companyId).ToList();
        }

        public void Update(Customer customer)
        {
            Customer Upcustomer = _contexDb.Customers.FirstOrDefault(s => s.Id == customer.Id);
            Upcustomer.Name = customer.Name;
            Upcustomer.Surname = customer.Surname;
            Upcustomer.Taxnumber = customer.Taxnumber;
            _contexDb.SaveChanges();
        }
    }
}
