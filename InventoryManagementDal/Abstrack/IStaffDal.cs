using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Abstrack
{
    public interface IStaffDal
    {
        List<Staff> GetAll();

        Staff Get(int Id);
        void Add(Staff staff);
        void Delete(int Id);
        void Update(Staff staff);

    }
}
