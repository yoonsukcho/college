using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Customers
    {

        public Customers()
        {
            Qnas = new HashSet<Qnas>();
            Receipts = new HashSet<Receipts>();
        }

        [Key]

        [Display(Name = "Customer ID")]
        public int customerID { get; set; }

        [Display(Name = "First Name")]
        public string custFName { get; set; }

        [Display(Name = "Last Name")]
        public string custLName { get; set; }

        [Display(Name = "Address")]
        public string custAddress { get; set; }

        [Display(Name = "City")]
        public string custCity { get; set; }

        [Display(Name = "Province")]
        public string custState { get; set; }

        [Display(Name = "Postal Code")]
        public string custZip { get; set; }

        [Display(Name = "Phone")]
        public string custPhone { get; set; }
        
        [Display(Name = "Email")]
        public string CustEmail { get; set; }// last entry in Customer
        
        public virtual ICollection<Qnas> Qnas { get; set; }
        public virtual ICollection<Receipts> Receipts { get; set; }

    }
}
