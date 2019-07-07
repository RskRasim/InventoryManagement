using InventoryManagementBll.Concrete;
using InventoryManagementDal.Concrete.EntityFramework;
using ICompanyAddressesServices.concrete.EntityFramework;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

using InventoryManagementUI.Models;

namespace InventoryManagementUI.Controllers
{
    [RoleControl(Roles = "Company")]
    public class CompanyController : Controller
    {
        private StaffManager staffManager;
        private ProductManager productManager;

        private CompanyAddressManager companyaddressManager;
        private CompanyManager companyManager;


        private RoleManager roleManager;

        public CompanyController()
        {
            staffManager = new StaffManager(new EfStaffDal());
            productManager = new ProductManager(new EfProductDal());

            companyaddressManager = new CompanyAddressManager(new EfCompanyAddressDal());
            companyManager = new CompanyManager(new EfCompanyDal());

            roleManager = new RoleManager(new RoleDal());

        }


        #region Company

        public ActionResult Index()
        {
            try
            {
                ViewBag.ProductCount = productManager.GetAllById((int)Session["Id"]).Count();
                ViewBag.ProductTotal = (float)productManager.GetAllById((int)Session["Id"]).Select(S => S.TotalProductValue).Sum();
                ViewBag.Nois = productManager.GetAllById((int)Session["Id"]).Select(s => s.Pieces).Sum();

                return View(staffManager.GetAllById((int)Session["Id"]));
            }
            catch (System.NullReferenceException)
            {
                return Redirect("~/Account/CompanyLogin");
            }

        }


        public ActionResult EditCompanyProfile()
        {
            try
            {
                return View(companyManager.Get((int)Session["Id"]));
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        [HttpPost]
        public ActionResult EditCompanyProfile(string Password)
        {
            try
            {
                Company companyUp = new Company
                {
                    Id = (int)Session["Id"],
                    Name = Request.Form["Name"],
                    TaxNumber = Request.Form["TaxNumber"],
                    Password = Crypto.Hash(Password, "sha256"),
                };

                CompanyAddress companyAddressUp = new CompanyAddress
                {
                    Address = Request.Form["Address"],
                    CompanyId = (int)Session["Id"]
                };

                companyManager.Update(companyUp);
                companyaddressManager.Update(companyAddressUp);
                return RedirectToAction("EditCompanyProfile");

            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        #endregion



        #region Staff Actions

        public ActionResult Staff()
        {
            //ViewBag.ProductCount = productManager.GetAllById((int)Session["Id"]).Count();
            return View(staffManager.GetAllById((int)Session["Id"]));
        }



        public ActionResult CreateStaff()
        {
            return View();
        }


        public ActionResult EditStaff(int Id = 0)
        {
            try
            {
                Staff staff = staffManager.Get(Id, (int)Session["Id"]);

                if (staff != null)
                {
                    return View(staff);
                }
                else
                {
                    TempData["NotStaff"] = "OHH! Sorry I couldn't find a Staff like this";
                    return RedirectToAction("Staff");
                }
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        [HttpPost]

        public ActionResult EditStaff()
        {
            Staff UpStaff = new Staff
            {
                Id = Convert.ToInt32(Request.Form["Id"]),
                Name = Request.Form["Name"],
                Surname = Request.Form["Surname"],
                Username = Request.Form["Username"],
                Department = Request.Form["Department"],
                Task = Request.Form["Task"],
                Phone = Request.Form["Phone"],
                Email = Request.Form["Email"],
                Password = Crypto.Hash(Request.Form["Password"], "sha256"),

            };
            staffManager.Update(UpStaff);
            return RedirectToAction("Staff");
        }

        [HttpPost]

        public ActionResult CreateStaff(string Password)
        {
            try
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
                    IsActive = true,
                    //Oturuma Göre Düzenlenecek
                    CompanyId = (int)Session["Id"],

                };
                staffManager.Add(staff);
                Role role = new Role
                {
                    RoleName = "Staff",
                    UserName = Request.Form["Email"],
                    CompanyId = (int)Session["Id"]

                };

                roleManager.Add(role);
                return RedirectToAction("Staff");
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        public ActionResult DeleteStaff(int Id = 0)
        {
            staffManager.IsActivet(Id, (int)Session["Id"]);
            return RedirectToAction("Staff");
        }


        #endregion



    }
}