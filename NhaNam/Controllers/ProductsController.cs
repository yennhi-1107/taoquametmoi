using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaNam.Models;
using System.IO;


namespace NhaNam.Controllers
{
    public class ProductsController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();

        // GET: Products
        public ActionResult Index(string SearchString = "")
        {
            if (SearchString != "")
            {
                var proDucts = db.Products.Include(p => p.Category).Where(x => x.ProName.ToUpper().Contains(SearchString.ToUpper()));
                return View(proDucts.ToList());

            }
            var products = db.Products.Include(p => p.Category).Include(p => p.Comment);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            ViewBag.ProID = new SelectList(db.Comments, "ProID", "CommentText");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,ProName,CatID,ProImage,NameDescription," + "CreateDate, UploadImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    string path = "~/Content/Images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                product.CreatedDate = DateTime.Today;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            ViewBag.ProID = new SelectList(db.Comments, "ProID", "CommentText", product.ProID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            ViewBag.ProID = new SelectList(db.Comments, "ProID", "CommentText", product.ProID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,ProName,CatID,ProImage,NameDescription," +
            "CreatedDate, UploadImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    string path = "~/Content/Images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            ViewBag.ProID = new SelectList(db.Comments, "ProID", "CommentText", product.ProID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
