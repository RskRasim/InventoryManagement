using InventoryManagementBll.Concrete;
using ICompanyAddressesServices.concrete.EntityFramework;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace InventoryManagementUI.Controllers
{
    public class CompanyController : Controller
    {
        private StaffManager staffManager;
        private ProductManager productManager;
        private ProductImagesManager producImgManager;
        private CompanyAddressManager companyaddressManager;
        private CompanyManager companyManager;

        public CompanyController()
        {
            staffManager = new StaffManager(new EfStaffDal());
            productManager = new ProductManager(new EfProductDal());
            producImgManager = new ProductImagesManager(new EfProductImagesDal());
            companyaddressManager = new CompanyAddressManager(new EfCompanyAddressDal());
            companyManager = new CompanyManager(new EfCompanyDal());
        }


        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                ViewBag.ProductCount = productManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]).Count();
                ViewBag.ProductTotal = (float)productManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]).Select(S => S.TotalProductValue).Sum();
                ViewBag.Nois = productManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]).Select(s => s.Pieces).Sum();

                return View(staffManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]));
            }
            catch (System.NullReferenceException)
            {

                return Redirect("~/Account/CompanyLogin");
            }
        
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditCompanyProfile(int Id)
        {
            return View(companyManager.Get(Id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditCompanyProfile()
        {
            Company companyUp = new Company
            {
                Id = (int)Session["Id"],
                Name = Request.Form["Name"],
                TaxNumber = Request.Form["TaxNumber"],
                Password = Crypto.Hash(Request.Form["Password"], "sha256"),
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

        /* ----- Company End -----*/

        /* ----- Product Actions Start ------*/
        [Authorize]
        public ActionResult Product()
        {
            return View(productManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]));
        }
        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddProduct(HttpPostedFileBase Img, int ShelfNumber = 0, int Pieces = 0, int MaxPieces = 0, int TaxRate = 0, int MinPieces = 0, decimal Price = 0)
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
                StoreId = 1,
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
        [HttpGet]
        [Authorize]
        public ActionResult DetailProduct(int Id)
        {

            return View(productManager.Get(Id));
        }
        [HttpGet]
        [Authorize]
        public ActionResult DeleteProduct(int Id)
        {
            productManager.Delete(Id);
           return RedirectToAction("Product");
        }

        /* ----- Product Actions End ------ */

        /* ----- Staff Actions Start ----- */
        [Authorize]
        public ActionResult Staff()
        {
            ViewBag.ProductCount = productManager.GetAll().Where(s => s.CompanyId == (int)Session["Id"]).Count();
            return View(staffManager.GetAll().Where(s=> s.CompanyId == (int)Session["Id"]));
        }


        [Authorize]
        public ActionResult CreateStaff()
        {
            return View();
        }


        public ActionResult EditStaff(int Id)
        {
            return View(staffManager.Get(Id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditStaff()
        {
            Staff UpStaff = new Staff
            {
                Id =Convert.ToInt32(Request.Form["Id"]),
                Name = Request.Form["Name"],
                Surname = Request.Form["Surname"],
                Username = Request.Form["Username"],
                Department = Request.Form["Department"],
                Task = Request.Form["Task"],
                Phone = Request.Form["Phone"],
                Email = Request.Form["Email"],
                Password= Crypto.Hash(Request.Form["Password"], "sha256"),
               
            };
            staffManager.Update(UpStaff);
            return RedirectToAction("Staff");
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateStaff(string Password)
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
                //Oturuma Göre Düzenlenecek
                CompanyId = (int)Session["Id"],

            };
            staffManager.Add(staff);
            return RedirectToAction("Staff");
        }
        [Authorize]
        public ActionResult DeleteStaff(int Id)
        {
            staffManager.Delete(Id);
            return RedirectToAction("Staff");
        }


        /* ------ Staff Actions End ----- */
    }
}