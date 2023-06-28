using EcommerseWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EcommerseWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbCotext db;
        private CategoryCRUD crud;
        private ProductCRUD _db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public ProductController(ApplicationDbCotext db, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
           this.db=db;
            crud=new CategoryCRUD(this.db);
            _db=new ProductCRUD(this.db);
            this.env=env;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var category = crud.GetCategories();
            var list = _db.GetProducts();
            foreach(var item in list)
            {
               foreach(var i in category)
                {
                    if(item.categoryid == i.categoryid)
                    {
                        item.categoryname = i.categoryname;
                    }
                }
            }
            return View(list);
        }

        public ActionResult ProductList()
        {
            var list = _db.GetProducts();
            return View(list);
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var p = _db.GetProductById(id);
            return View(p);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = crud.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile file)
        {
            try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\Images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                product.ImageUrl = "~/Images/" + file.FileName;
                int resut = _db.AddProduct(product);
                if (resut > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Catagories=crud.GetCategories();
            var product = _db.GetProductById(id);

            HttpContext.Session.SetString("oldImageurl",product.ImageUrl);
            var p = _db.GetProductById(id);
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, IFormFile file)
        {
            try
            {
                string oldimageurl = HttpContext.Session.GetString("oldImageUrl");
                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\Images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    product.ImageUrl = "~/Images/" + file.FileName;

                    string[] str = oldimageurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\Images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    product.ImageUrl = oldimageurl;
                }
                int result = _db.EditProduct(product);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var p = _db.GetProductById(id);
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = _db.DeleteProduct(id);
                if(result>0)

                return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
