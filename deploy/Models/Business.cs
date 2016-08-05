using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace deploy.Models
{
    public class Business
    {
        public int BusinessID { get; set; }
        [MaxLength(50)]
        public string BusinessName { get; set; }
        public int BusinessTypeID { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Hours { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public string Menu { get; set; }
        //public string ApplicationUserID { get; set; }


        //Navigation Properties
        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual BusinessType BusinessType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}