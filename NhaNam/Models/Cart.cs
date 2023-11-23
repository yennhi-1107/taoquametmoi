using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaNam.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public Cart()
        {
            this.Items = new List<CartItem>();
        }
        public void AddToCart(CartItem item, int Quantity)
        {
            var checkExit = Items.FirstOrDefault(s => s._productId.ProID == item._productId.ProID);
            if (checkExit != null)
            {
                checkExit._quantity += Quantity;
                checkExit.ToTalPrice = checkExit.Price * checkExit._quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove_CartItem(int id)
        {
            var checkExits = Items.SingleOrDefault(s => s._productId.ProID == id);
                if(checkExits != null)
            {
            Items.Remove(checkExits);
            }    
        }
        public void Update_quantity(int id, int _new_quan)
        {
            var  checkExits = Items.SingleOrDefault(s => s._productId.ProID == id);
            if (checkExits != null)
            {
                checkExits._quantity = _new_quan;
                checkExits.ToTalPrice = checkExits.Price * checkExits._quantity;
            }
        }
        public decimal ToTal()
        {
            return Items.Sum(s => s.ToTalPrice);
        }
        public void ClearCart()
        {
            Items.Clear();
        }
        public int Total_quantity()
        {
            return Items.Sum(s => s._quantity);
        }
        public void Add_Product_Cart(Product _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._productId.ProID == _pro.ProID);
            if (item == null)
                Items.Add(new CartItem
                {
                    _productId = _pro,
                    _quantity = _quan
                });
            else
                item._quantity += _quan;
        }
        public class CartItem
        {
            public Product _productId { get; set; }
            public Product _productName { get; set; }
            public int _quantity { get; set; }
            public ProDetail _proDetail { get; set; }
            public decimal CategoryName { get; set; }
            public decimal ProImage { get; set; }
            public decimal ToTalPrice { get; set; }
            public decimal Price { get; set; }
        }
    }
}
