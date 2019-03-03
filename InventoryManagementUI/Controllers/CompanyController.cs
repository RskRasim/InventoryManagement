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

        public CompanyController(StaffManager staffManager, ProductManager productManager)
        {
            this.staffManager = staffManager;
            this.productManager = productManager;
        }


        // GET: Company
        public ActionResult Index()
        {
            ViewBag.ProductCount = productManager.GetAll().Count();
            return View(staffManager.GetAll());
        }
    }
}