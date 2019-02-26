using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
   public interface IStaffService
    {

        void Add(Staff staff);
        void Delete(int Id);
        void Update(Staff staff);
        List<Staff> GetAll();
        Staff Get(int Id);




    }
}
