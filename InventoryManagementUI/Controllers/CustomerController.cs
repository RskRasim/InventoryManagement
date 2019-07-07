using InventoryManagementBll.Concrete;
using InventoryManagementDal.Concrete.EntityFramework;
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
    public class CustomerController : Controller
    {
        private CustomerManager customerManager;
        public CustomerController()
        {
            customerManager = new CustomerManager(new EfCustomerDal());
        }
        // GET: Customer
        public ActionResult List()
        {
            try
            {
                return View(customerManager.GetAllById((int)Session["Id"]));
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
        public ActionResult Add(string Name, string Surname, string Taxnumber, string CompanyName)
        {
            try
            {
                Customer customer = new Customer
                {
                    Name = Name,
                    Surname = Surname,
                    Taxnumber = Taxnumber,
                    CompanyName = CompanyName,
                    CompanyId = (int)Session["Id"]

                };
                customerManager.Add(customer);

                return View();
            }
            catch (System.NullReferenceException)
            {
                return Redirect("~/Account/CompanyLogin");
            }

        }


        public ActionResult Detail(int Id)
        {

            return View(customerManager.Get(Id, (int)Session["Id"]));
        }
    }
}