using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Branchs
    {

        [Key]

        [Display(Name = "Branch ID")]
        public int branchID { get; set; }

        [Display(Name = "Branch Name")]
        public string branchName { get; set; }

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

    }
}
