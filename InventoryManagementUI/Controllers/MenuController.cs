using InventoryManagementBll.Concrete;
using InventoryManagementDal.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Controllers
{
    public class MenuController : Controller
    {
        MenuManager menuManager = new MenuManager(new EfMenuDal());

        // GET: Menu
        public PartialViewResult Menus()
        {
            return PartialView(menuManager.GetAll());
        }
    }
}