using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Receipts
    {
        [Key]

        [Display(Name = "Receipt ID")]
        public int receiptID { get; set; }

        [Display(Name = "Order ID")]
        public int orderID { get; set; }

        [Display(Name = "Payment Method")]
        public string paymentMethod { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime paymentDate { get; set; }

        public virtual Orders OrderIDNavigation { get; set; }
    }
}
