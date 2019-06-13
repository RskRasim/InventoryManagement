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
        private ProductImagesManager producImgManager;
        private CompanyAddressManager companyaddressManager;
        private CompanyManager companyManager;
        private StoreManager storeManager;
        private CustomerManager customerManager;
        private RoleManager roleManager;

        public CompanyController()
        {
            staffManager = new StaffManager(new EfStaffDal());
            productManager = new ProductManager(new EfProductDal());
            producImgManager = new ProductImagesManager(new EfProductImagesDal());
            companyaddressManager = new CompanyAddressManager(new EfCompanyAddressDal());
            companyManager = new CompanyManager(new EfCompanyDal());
            storeManager = new StoreManager(new EfStoreDal());
            customerManager = new CustomerManager(new EfCustomerDal());
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

        #region Product Actions

        public ActionResult Product()
        {
            try
            {
                return View(productManager.GetAllById((int)Session["Id"]));
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }

        public ActionResult AddProduct()
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

        [HttpPost]

        public ActionResult AddProduct(HttpPostedFileBase Img, int store, int ShelfNumber = 0, int Pieces = 0, int MaxPieces = 0, int TaxRate = 0, int MinPieces = 0, decimal Price = 0)
        {
            try
            {
                Product product = new Product
                {
                    BarcodeCode = Request.Form["BarcodeCode"],
                    BarcodeCode2 = Request.Form["BarcodeCode2"],
                    ProductCode = Request.Form["ProductCode"],
                    ProductName = Request.Form["ProductName"],
                    Content = Request.Form["Content"],
                    ShelfNumber = ShelfNumber,
                    Pieces = Pieces,
                    Price = Price,
                    Total = (Price * TaxRate / 100) + Price,
                    TotalProductValue = Pieces * Price,
                    MaxPieces = MaxPieces,
                    MinPieces = MinPieces,
                    TaxRate = TaxRate,
                    InsertionDate = DateTime.Now,

                    //Oturuma Göre Düzenlenecek
                    CompanyId = (int)Session["Id"],
                    StoreId = store,
                    IsActive = true


                };

                productManager.Add(product);

                if (Img != null)
                {


                    Random random = new Random();
                    int prefix = random.Next();

                    string ImgName = +prefix + Img.FileName;

                    Img.SaveAs(HttpContext.Server.MapPath("~/Content/ProductImg/" + ImgName));
                    ProductImage productImg = new ProductImage
                    {
                        ImgFolder = ImgName.ToString(),
                        ProductId = product.Id
                    };

                    producImgManager.Add(productImg);

                }

                else
                {
                    ProductImage productImg = new ProductImage
                    {
                        ImgFolder = "noimage.jpg",
                        ProductId = product.Id
                    };

                    producImgManager.Add(productImg);
                }


                return RedirectToAction("Product");
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }


        }
        [HttpGet]

        public ActionResult DetailProduct(int Id = 0)
        {
            try
            {

                Product product = productManager.Get(Id, (int)Session["Id"]);
                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    TempData["NotProduct"] = "OHH! Sorry I couldn't find a product like this";
                    return RedirectToAction("Product");
                }



            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }




        }




        [HttpGet]

        public ActionResult DeleteProduct(int Id = 0)
        {
            try
            {
                int events = productManager.Delete(Id, (int)Session["Id"]);
                /*İşlem sayısı 0 gelirse ürün company ürünü değil*/
                TempData["DeleteNum"] = "Number of deleted items:" + events;
                return RedirectToAction("Product");
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

        #region Store Actions

        public ActionResult Store()
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


        public ActionResult AddStore()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddStore(string Name, string Address, string StoreManager)
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
                return View("AddStore");
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }

        }
        #endregion

        #region Customer Actions

        public ActionResult Customer()
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

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(string Name, string Surname, string Taxnumber, string CompanyName)
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

        public ActionResult DetailCustomer(int Id)
        {

            return View(customerManager.Get(Id, (int)Session["Id"]));
        }
        #endregion
    }
}