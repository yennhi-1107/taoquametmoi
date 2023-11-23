using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaNam.Models;


namespace NhaNam.Controllers
{
    public class HomeController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MasterLayout()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult ProDetail()
        {
            return View();
        }
    }
}