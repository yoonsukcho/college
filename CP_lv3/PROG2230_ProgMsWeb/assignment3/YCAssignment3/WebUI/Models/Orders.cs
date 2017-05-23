using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Orders
    {
        [Key]

        [Display(Name = "Order ID")]
        public int orderID { get; set; }

        [Display(Name = "Customer Name")]
        public string custName { get; set; }

        [Display(Name = "Customer Address")]
        public string custAddress { get; set; }

        [Display(Name = "Payment Method")]
        public string paymentMethod { get; set; }

        [Display(Name = "Delivery Date")]
        public DateTime deliveryDate { get; set; }

        [Display(Name = "Order Email")]
        public string OrderEmail { get; set; }// last entry in Order


    }
}
