using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaNam.Models;

namespace NhaNam.Controllers
{
    public class CheckOrderController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        // GET: CheckCart
        public ActionResult CheckCart()
        {
            return View();
        }
        public ActionResult CheckCart(Order order)
        {
            var check = db.Orders.Where(s => s.OrderID == order.OrderID).FirstOrDefault();
            if (check == null) //login sai thong tin
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = order.OrderID;
                return RedirectToAction("Index", "Product");
            }
        }
    }
}