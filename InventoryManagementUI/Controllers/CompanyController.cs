using InventoryManagementBll.Concrete;
using InventoryManagementDal.concrete.EntityFramework;
using InventoryManagementDal.Concrete.EntityFramework;
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
        private StaffManager staffManager = new StaffManager(new EfStaffDal());
        private ProductManager productManager = new ProductManager(new EfProductDal());
        private ProductImagesManager producImgManager = new ProductImagesManager(new EfProductImagesDal());


        // GET: Company
        public ActionResult Index()
        {
            ViewBag.ProductCount = productManager.GetAll().Count();
            ViewBag.ProductTotal =(float)productManager.GetAll().Select(S => S.TotalProductValue).Sum();
            ViewBag.Nois = productManager.GetAll().Select(s => s.Pieces).Sum();
                
           return View(staffManager.GetAll());
        }
        /* ----- Product Actions Start ------*/ 
        public ActionResult Product()
        {
            return View(productManager.GetAll());
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase Img, int ShelfNumber =0, int Pieces=0,int MaxPieces=0,int TaxRate=0, int MinPieces=0, decimal Price=0)
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
                TotalProductValue = Pieces*Price,
                MaxPieces = MaxPieces,
                MinPieces = MinPieces,
                TaxRate = TaxRate,
                InsertionDate = DateTime.Now,

                //Oturuma Göre Düzenlenecek
                CompanyId = 2,
                StoreId = 1,
                IsActive = true
                

            };

            productManager.Add(product);

            if (Img!=null)
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


            return RedirectToAction("Product");
        }


        /* ----- Product Actions End ------ */

        /* ----- Staff Actions Start ----- */

        public ActionResult Staff()
        {
            ViewBag.ProductCount = productManager.GetAll().Count();
            return View(staffManager.GetAll());
        }



        public ActionResult CreateStaff()
        {
            return View();
        }


        public ActionResult EditStaff(int Id)
        {
            return View(staffManager.Get(Id));
        }
        [HttpPost]
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
                CompanyId = 2

            };
            staffManager.Add(staff);
            return RedirectToAction("Staff");
        }
    
        public ActionResult DeleteStaff(int Id)
        {
            staffManager.Delete(Id);
            return RedirectToAction("Staff");
        }


        /* ------ Staff Actions End ----- */
    }
}