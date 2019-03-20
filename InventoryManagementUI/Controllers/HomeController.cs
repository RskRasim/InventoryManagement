using InventoryManagementBll.Concrete;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Controllers
{
    public class HomeController : Controller
    {
        StaffManager staffManager;
        
        public HomeController()
        {
            staffManager = new StaffManager(new EfStaffDal());
        }

       
        // GET: Home
        public ActionResult Index()
        {
          List<Staff> staffs= staffManager.GetAll();

            return View(staffs);
        }
        /*Project Test - Staff*/
        [HttpPost]
        public ActionResult StaffAdd()
        {
            Staff staff = new Staff
            {
                Name =Request.Form["Name"],
                Surname    =    Request.Form["Surname"],
                Username = Request.Form["Username"],
                Phone = Request.Form["Phone"],
                Department = Request.Form["Department"],
                Task = Request.Form["Task"],
                Password = Request.Form["Password"],
                CompanyId = 2
                
            };
            staffManager.Add(staff);
            return RedirectToAction("Index");
        }
       [HttpGet]
       public ActionResult StaffDelete(int Id)
        {
            staffManager.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}