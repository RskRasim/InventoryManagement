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

namespace InventoryManagementUI.Controllers
{
    public class AccountController : Controller
    {
        private AuthenticationManager authenticationManager;
        public AccountController()
        {
            authenticationManager = new AuthenticationManager(new EfAuthenticationDal());

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
                FormsAuthentication.SetAuthCookie(company.TaxNumber, false);

                try
                {
                    Session["TaxNumber"] = company.TaxNumber;
                    Session["CompanyName"] = company.Name;
                    Session["CompanyLogo"] = company.CompanyLogoes.Where(s => s.CompanyId == company.Id).FirstOrDefault().Folder;

                    Session["Id"] = company.Id;
                    return Redirect("~/Company/Index");
                }
                catch (System.NullReferenceException)
                {
                    Session["TaxNumber"] = company.TaxNumber;
                    Session["CompanyName"] = company.Name;
               

                    Session["Id"] = company.Id;
                    /*Tek Boş Gelebilecek Session*/
                    Session["CompanyLogo"] = "noimage.jpg";
                    return Redirect("~/Company/Index");
                }
                //String companyLogo = company.CompanyLogoes.Where(s => s.CompanyId == company.Id).FirstOrDefault().Folder;

              
               
            }

            return View("CompanyLogin");

        }



        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("CompanyLogin");
        }
    }
}