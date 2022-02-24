using MVcWithOutEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVcWithOutEntity.Controllers
{
    public class ProductController : Controller
    {
        ProductDBoperations prdb = new ProductDBoperations();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(prdb.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ProductModel product)
        {
            return Json(prdb.AddProduct(product), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(int id)
        {
            var Product = prdb.ListAll().Find(x => x.ProductID.Equals(id));
            return Json(Product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ProductModel product)
        {
            return Json(prdb.Update(product), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(prdb.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}
