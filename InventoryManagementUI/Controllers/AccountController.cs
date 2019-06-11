using InventoryManagementBll;
using ICompanyAddressesServices.Concrete;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;
using InventoryManagementBll.Concrete;
using ICompanyAddressesServices.concrete.EntityFramework;
using InventoryManagementDal.Concrete.EntityFramework;

namespace InventoryManagementUI.Controllers
{
    public class AccountController : Controller
    {
        private AuthenticationManager authenticationManager;
        private CompanyManager companyManager;
        private CompanyAddressManager companyAddressManager;
        private EmailManager emailManager;
        private RoleManager roleManager;

        public AccountController()
        {
            authenticationManager = new AuthenticationManager(new EfAuthenticationDal());
            companyManager = new CompanyManager(new EfCompanyDal());
            companyAddressManager = new CompanyAddressManager(new EfCompanyAddressDal());
            emailManager = new EmailManager();
            roleManager = new RoleManager(new RoleDal());
        }

        // GET: Account
        public ActionResult CompanyLogin()
        {
            return View();
        }

        #region Şirket İçin Login İşlemi
        [HttpPost]
        public ActionResult CompanyLogin(string TaxNumber, string Password)
        {
            Company user = new Company
            {
                TaxNumber = TaxNumber,
                Password = Crypto.Hash(Password, "sha256"),
            };

            Company company = authenticationManager.AuthenticationCompany(user);

            if (company != null)
            {
                FormsAuthentication.SetAuthCookie(company.TaxNumber, false);
                try
                {

                    Session["TaxNumber"] = company.TaxNumber;
                    Session["CompanyName"] = company.Name;
                    Session["CompanyLogo"] = company.CompanyLogoes.Where(s => s.CompanyId == company.Id).FirstOrDefault().Folder;
                    Session["Id"] = company.Id;
                    Session.Timeout = 60;
                    return Redirect("~/Company/Index");
                }
                catch (System.NullReferenceException)
                {

                    Session["TaxNumber"] = company.TaxNumber;
                    Session["CompanyName"] = company.Name;
                    Session["Id"] = company.Id;
                    Session.Timeout = 60;
                    Session["CompanyLogo"] = "noimage.jpg";
                    return Redirect("~/Company/Index");
                }


                //String companyLogo = company.CompanyLogoes.Where(s => s.CompanyId == company.Id).FirstOrDefault().Folder;
            }
            else
            {
                return View("CompanyLogin");
            }

        }
        #endregion

        public ActionResult CreateCompanyAccount()
        {
            return View();
        }

        #region Yeni Şirket Kaydı
        [HttpPost]
        public ActionResult CreateCompanyAccount(string Password)
        {
            Company company = new Company
            {
                Name = Request.Form["Name"],
                TaxNumber = Request.Form["TaxNumber"],
                Email = Request.Form["Email"],
                Password = Crypto.Hash(Password, "sha256"),
                IsActive = true,
                //Role = "Company"

            };
            bool Cntr = companyManager.Add(company);

            if (Cntr)
            {
                CompanyAddress companyAddress = new CompanyAddress
                {
                    Address = "null",
                    CompanyId = company.Id
                };

                companyAddressManager.Add(companyAddress);

                Role role = new Role
                {
                    UserName = Request.Form["TaxNumber"],
                    RoleName = "Company",
                    CompanyId = company.Id

                };

                roleManager.Add(role);

                emailManager.SendMail(company.Email, company.Name);

                return View("CompanyLogin");

            }
            else
            {
                ViewBag.Company = "There is a company in this tax number";
                return View();
            }

        }
        #endregion

        public ActionResult StaffLogin()
        {
            return View();
        }
        #region Personel(Staff) İçin Login İşlemi. Personel(Staff) Kaydı CompanyControlllerde yapılıyor
        [HttpPost]
        public ActionResult StaffLogin(string Email, string Password)
        {

            FormsAuthentication.SetAuthCookie(Email, false);

            Staff user = new Staff
            {
                Email = Email,
                Password = Crypto.Hash(Password, "sha256"),
            };

            Staff staff = authenticationManager.AuthenticationStaff(user);

            if (staff != null)
            {
                return Redirect("~/Staff/Index");
            }
            else
            {
                return View("StaffLogin");
            }

        }
        #endregion

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("CompanyLogin");
        }
    }
}