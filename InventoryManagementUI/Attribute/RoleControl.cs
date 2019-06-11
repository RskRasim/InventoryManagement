using ICompanyAddressesServices.concrete.EntityFramework;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementBll.Concrete;
using InventoryManagementDal.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Models
{
    public class RoleControl : AuthorizeAttribute
    {/*Henüz tamamlanmadı sadece CompanyControl Çalışmakta*/
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
                httpContext.Response.Redirect("~/Account/CompanyLogin");
            }

            //cookie'deki kullanıcı idsini alıyorum
            string rolid = httpContext.User.Identity.Name;
            //idsini aldığım kullanıcıyı db'den çekiyorum
            /******************Role tablosundan gelicek veri test amaçlı*********************/

            var user = roleManager.GetRole(rolid);

            var roles = Roles.Split(',');

            if (user != null)
            {


                if (user.RoleName == "Company")
                {
                    if (roles.Contains("Company"))
                        return true;
                }
                //kullanıcı company ise
                else if (user.RoleName == "Staff")
                {
                    if (roles.Contains("Staff"))
                        return true;
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}