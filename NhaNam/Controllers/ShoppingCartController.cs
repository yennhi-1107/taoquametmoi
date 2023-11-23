using NhaNam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NhaNam.Models.Cart;

namespace NhaNam.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmtyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code =new { Success=false, msg = "", code=-1, count =0 };

            var db = new ApplicationDbContext();//theodb

            var checkProduct = db.Products.FirstOrDefault(s => s.Id = id);

            if (checkProduct != null)

            {
                Cart cart = (Cart) Session["Cart"];
                if(cart==null)
                {
                    cart = new Cart();
                }
                CartItem item = new CartItem

                {

                    _productId = checkProduct.id,

                    _productName = checkProduct.Title,

                    CategoryName = checkProduct.Productcategory.Title,

                    _quantity = quantity
                };
                if (checkProduct.ProductImage.FirstOrDefault(x => x.IsDefault) != null)
                {

                    item.ProImage = checkProduct.ProductImage.FirstOrDefault(x => x.IsDefault).Image;

}

                item.Price = checkProduct.Price;

                if (checkProduct.PriceSale > 0)

                {

                }

                item.Price = (decimal)checkProduct.PriceSale;

                item.ToTalPrice = item._quantity * item.Price;

                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giở hàng thành công!", code = 1, count = cart.Items.Count };
                }
                return Json(code);
            }
        public ActionResult Update_Cart_Quantity(FormCollection form) 
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int id_quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, id_quantity );
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart; cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order(); //Bang Hoa Don San pham 
                _order.OrderDate = DateTime.Now;
                _order.AddressDeliverry = form["AddressDelivery"];
                foreach (var item in cart.Items)
                {
                    OrderDetail _order_detail = new OrderDetail(); //Luu dong san pham vao bang Chi tiet Hoa don
                    _order_detail.OrderID = _order.OrderID;
                    _order_detail.ProSupID = item._productId.ProID;
                    _order_detail.UnitPrice = (double)item._proDetail.UnitPrice;
                    _order_detail.Quantity = item._quantity;
                    db.OrderDetails.Add(_order_detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "ShoppingCart");
            }
            catch
            { return Content("Lỗi. Vui lòng kiểm tra thông tin khách hàng"); }

        }
        //public ActionResult CheckoutS1(FormCollection form)
        //{

        //}
        //public ActionResult CheckoutS2(FormCollection form)
        //{

        //}
        //public ActionResult CheckoutS3(FormCollection form)
        //{

        //}
    }
}
