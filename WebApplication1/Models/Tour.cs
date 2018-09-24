using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Tour
    {
        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTourStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTourEnd { get; set; }

        //public Tourist Tourist { get; set; }

        public int Price { get; set; }

        public IEnumerable<SelectListItem> Tours { get; set; }

        public string SelectedTour { get; set; }

        public Database1Entities db = new Database1Entities();
    }
}