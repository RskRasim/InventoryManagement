using ICompanyAddressesServices.concrete.EntityFramework;
using ICompanyAddressesServices.Concrete.EntityFramework;
using InventoryManagementBll.Concrete;
using InventoryManagementEntity;
using InventoryManagementUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementUI.Controllers
{

    [RoleControl(Roles = "Company")]
    public class ProductController : Controller
    {
        private ProductManager productManager;
        private ProductImagesManager producImgManager;
        private StoreManager storeManager;
        public ProductController()
        {
            productManager = new ProductManager(new EfProductDal());
            producImgManager = new ProductImagesManager(new EfProductImagesDal());
            storeManager = new StoreManager(new EfStoreDal());

        }
        // GET: Product
        public ActionResult List()
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

        public ActionResult Add()
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
        public ActionResult Add(HttpPostedFileBase Img, int store, int ShelfNumber = 0, int Pieces = 0, int MaxPieces = 0, int TaxRate = 0, int MinPieces = 0, decimal Price = 0)
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
        public ActionResult Detail(int Id = 0)
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


        public ActionResult Delete(int Id = 0)
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
        public ActionResult Edit()
        {
            return View();
        }
    }
}