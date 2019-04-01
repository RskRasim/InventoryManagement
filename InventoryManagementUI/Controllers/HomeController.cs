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
     
       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      
    }
}