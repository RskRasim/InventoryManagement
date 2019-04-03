using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Abstrack
{
    public interface ICustomerDal
    {
        void Add(Customer customer);
        void Delete(int Id);
        void Update(Customer customer);

        Customer Get(int Id,int companyId);
        List<Customer> GetAll(int Id);
        List<Customer> GetAllById(int companyId);
    }
}
