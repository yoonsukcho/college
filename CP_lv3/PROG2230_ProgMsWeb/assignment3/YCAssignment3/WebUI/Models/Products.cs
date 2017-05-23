using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product ID")]
        public int productID { get; set; }

        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Display(Name = "Price")]
        public decimal productPrice { get; set; }

        [Display(Name = "Image")]
        public string productImage { get; set; }

    }
}
