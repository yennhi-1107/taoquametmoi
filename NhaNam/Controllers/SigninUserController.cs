using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaNam.Models;


namespace NhaNam.Controllers
{
    public class SigninUserController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        // GET: LoginUser
        public ActionResult IndexSignin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(User _user)
        {
            var check = db.Users.Where(s => s.Username == _user.Email && s.Password == _user.Password).FirstOrDefault();

            if (check == null) //login sai thong tin
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index");
            }    
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = _user.Email;
                Session["Password"]=_user.Password;
                return RedirectToAction("Index", "Product");
            }
        }
        public ActionResult SignupUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignupUser(User _user)
        {
            if(ModelState.IsValid)
            {
                var check_Id = db.Users.Where(s => s.Username == _user.Username).FirstOrDefault();
                if(check_Id==null)//chưa có id
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "Email đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}