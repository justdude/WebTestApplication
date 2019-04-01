using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        public int ProductCategoryID { get; set; }
    }
}