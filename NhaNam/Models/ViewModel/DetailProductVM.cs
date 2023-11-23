using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaNam.Models.ViewModel
{
    public class DetailProductVM
    {
        //thong tin Product Detail
        [Key]
        public int ProDeID { get; set; }
        public double OldPrice { get; set; }
        public double UnitPrice { get; set; }
        public int RemainQuantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<int> ViewQuantity { get; set; }

        //lay tu bang Product
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string NameDecription { get; set; }

        //lay tu bang Category
        public int CatID { get; set; }
        public string NameCate { get; set; }

        //lay tu bang Supplier
        public int SupID { get; set; }
        public string SupName { get; set; }
    }
}