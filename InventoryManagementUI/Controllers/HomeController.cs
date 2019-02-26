using InventoryManagementBll.Concrete;
using InventoryManagementDal.Concrete.EntityFramework;
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

            return View();
        }
        /*Test Staff*/
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
            return View();
        }
    }
}