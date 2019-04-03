using ICompanyAddressesServices.concrete.EntityFramework;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementBll.Concrete;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Models
{
    public class RoleControl : AuthorizeAttribute
    {
        private StaffManager staffManager;
        private CompanyManager companyManager;
        public RoleControl()
        {
            staffManager = new StaffManager(new EfStaffDal());
            companyManager = new CompanyManager(new EfCompanyDal());
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Kullanıcı giriş yapmamışsa login sayfasına at
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                httpContext.Response.Redirect("~/admin/login");
            }

            //cookie'deki kullanıcı idsini alıyorum
            string rolid = httpContext.User.Identity.Name;
            //idsini aldığım kullanıcıyı db'den çekiyorum
            /******************Role tablosundan gelicek veri test amaçlı*********************/
            var user = companyManager.GetAll().FirstOrDefault(s=> s.TaxNumber == rolid);
            var roles = Roles.Split(',');
            //kullanıcı admin ise 
            if (user.Role == "Company")
            {
                if (roles.Contains("Company"))
                    return true;
            }
            //kullanıcı company ise
           /* else if (user.IsCompany)
            {
                if (roles.Contains("Company"))
                    return true;
            }*/
            return base.AuthorizeCore(httpContext);
        }
    }
}