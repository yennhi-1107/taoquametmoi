using NhaNam.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaNam.Controllers
{
    public class DetailProductController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();

        // GET: DetailProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailProduct()
        {
            List<Product> listProduct = db.Products.ToList();
            return View();
        }
    }
}