using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace deploy.Models
{
    public class BusinessType
    {
        public int BusinessTypeID { get; set; }
        [MaxLength(50)]
        public string BusinessTypeName { get; set; }


        //Navigation Properties
        public virtual ICollection<Business> Businesses { get; set; }
    }
}