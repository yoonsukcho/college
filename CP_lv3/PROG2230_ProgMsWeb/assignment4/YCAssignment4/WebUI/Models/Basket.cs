using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Basket
    {
        public Basket()
        {
            Products = new HashSet<Products>();
        }

        [Key]

        [Display(Name = "Customer ID")]
        public int customerID { get; set; }

        [Display(Name = "Product ID")]
        public int productID { get; set; }

        [Display(Name = "Order ID")]
        public int orderID { get; set; }

        public virtual ICollection<Products> Products { get; set; }

    }
}
