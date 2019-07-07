using ICompanyAddressesServices.concrete.EntityFramework;
using InventoryManagementBll.Concrete;
using InventoryManagementEntity;
using InventoryManagementUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryManagementUI.Controllers
{
    [RoleControl(Roles = "Company")]
    public class StoreController : Controller
    {
        private StoreManager storeManager;
        public StoreController()
        {
            storeManager = new StoreManager(new EfStoreDal());
        }
        // GET: Store
        public ActionResult List()
        {
            try
            {
                return View(storeManager.GetAllById((int)Session["Id"]));
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }


        public ActionResult Add()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Add(string Name, string Address, string StoreManager)
        {
            try
            {
                Store store = new Store
                {
                    Name = Name,
                    Address = Address,
                    CompanyId = (int)Session["Id"],
                    StoreManager = StoreManager,
                    IsActive = true

                };
                storeManager.Add(store);
                return View("Add");
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
               
                return View("Add");
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }
    }
}