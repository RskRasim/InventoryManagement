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

namespace InventoryManagementUI.Controllers
{
    public class AccountController : Controller
    {
        private AuthenticationManager authenticationManager;
        private CompanyManager companyManager;
        private  CompanyAddressManager companyAddressManager;
        public AccountController()
        {
            authenticationManager = new AuthenticationManager(new EfAuthenticationDal());
            companyManager = new CompanyManager(new EfCompanyDal());
            companyAddressManager = new CompanyAddressManager(new EfCompanyAddressDal());

        }

        // GET: Account
        public ActionResult CompanyLogin()
        {
            return View();
        }

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
                FormsAuthentication.SetAuthCookie(company.TaxNumber,false);
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

        public ActionResult CreateCompanyAccount()
        {
            return View();
        }
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
                Role = "Company"
               
            };
            companyManager.Add(company);
            CompanyAddress companyAddress = new CompanyAddress
            {
                Address = "null",
                CompanyId = company.Id
            };
            
            companyAddressManager.Add(companyAddress);


            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("CompanyLogin");
        }
    }
}