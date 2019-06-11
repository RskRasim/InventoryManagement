using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Areas.Master.Controllers
{
    public class HomeController : Controller
    {
        // GET: Master/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}