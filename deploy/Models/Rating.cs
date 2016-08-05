using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deploy.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int BusinessID { get; set; }
        public short? StarReview { get; set; }
        public string TextReview { get; set; }


        //Navigation Properties
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Business Business { get; set; }
    }
}