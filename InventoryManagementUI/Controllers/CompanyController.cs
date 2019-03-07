using InventoryManagementBll.Concrete;
using InventoryManagementDal.concrete.EntityFramework;
using InventoryManagementDal.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InventoryManagementUI.Controllers
{
    public class CompanyController : Controller
    {
        private StaffManager staffManager = new StaffManager(new EfStaffDal());
        private ProductManager productManager = new ProductManager(new EfProductDal());


        // GET: Company
        public ActionResult Index()
        {
            ViewBag.ProductCount = productManager.GetAll().Count();
            return View(staffManager.GetAll());
        }
        //Staff Actions

        public ActionResult Staff()
        {
            ViewBag.ProductCount = productManager.GetAll().Count();
            return View(staffManager.GetAll());
        }



        public ActionResult CreateStaff()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult CreateStaff(string Password)
        {
            Staff staff = new Staff
            {
                Name = Request.Form["Name"],
                Surname = Request.Form["Surname"],
                Username = Request.Form["Username"],
                Phone = Request.Form["Phone"],
                Department = Request.Form["Department"],
                Task = Request.Form["Task"],
                Email = Request.Form["Email"],
                Password = Crypto.Hash(Password, "sha256"),
                CompanyId = 2

            };
            staffManager.Add(staff);
            return RedirectToAction("Staff");
        }
    
        public ActionResult DeleteStaff(int Id)
        {
            staffManager.Delete(Id);
            return RedirectToAction("Staff");
        }


        //Staff Actions End
    }
}