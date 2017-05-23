using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Qnas
    {
        [Key]
        [Display(Name = "Q&A ID")]
        public int qnaId { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Content")]
        public string content { get; set; }

        [Display(Name = "View Count")]
        public int view { get; set; }

        [Display(Name = "Date")]
        public DateTime createDate { get; set; }

        [Display(Name = "Customer ID")]
        public int customerID { get; set; }

        public virtual Customers CustomerIDNavigation { get; set; }

    }
}
