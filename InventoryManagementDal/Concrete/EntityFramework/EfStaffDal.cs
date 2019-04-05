using ICompanyAddressesServices.Abstrack;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Concrete.EntityFramework
{
    public class EfStaffDal : IStaffDal
    {
        private InventoryManagementContext _contexDb; 

        public EfStaffDal()
        {
            _contexDb  = new InventoryManagementContext();
        }

        public void Add(Staff staff)
        {
            _contexDb.Staffs.Add(staff);
            _contexDb.SaveChanges();
        }

        public int Delete(int Id, int companyId)
        {//Tüm delete işlemlerine ugulancak
            _contexDb.Staffs.Remove(_contexDb.Staffs.FirstOrDefault(s => s.Id == Id));
            int events = _contexDb.SaveChanges();
            return events;
        }

       

        public Staff Get(int Id, int companyId)
        {
            return _contexDb.Staffs.FirstOrDefault(s => s.Id == Id && s.CompanyId == companyId );
        }

        public List<Staff> GetAll()
        {
         return _contexDb.Staffs.ToList();
        }

        public List<Staff> GetAllById(int companyId)
        {
            return _contexDb.Staffs.Where(s => s.CompanyId == companyId).ToList();
        }

        public void Update(Staff staff)
        {
            Staff StaffUp = _contexDb.Staffs.FirstOrDefault(s => s.Id == staff.Id);
            StaffUp.Name = staff.Name;
            StaffUp.Surname = staff.Surname;
            StaffUp.Username = staff.Username;
            StaffUp.Task = staff.Task;
            StaffUp.Password = staff.Password;
            StaffUp.Phone = staff.Phone;
            StaffUp.Email = staff.Email;
            StaffUp.Department = staff.Department;

            _contexDb.SaveChanges();

        }
    }
}
