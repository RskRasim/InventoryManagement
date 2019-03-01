using InventoryManagementBll.Concrete;
using InventoryManagementDal.concrete.EntityFramework;
using InventoryManagementDal.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.ProductCount = (int)productManager.GetAll().Count();
            return View(staffManager.GetAll());
        }
    }
}