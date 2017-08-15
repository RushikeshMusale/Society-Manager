using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocietyManager.Models.SocietyModels
{
    public class FlatDetailsModel
    {
        public int FlatId { get; set; }
        [Required]
        public string FlatNumber { get; set; }
        [Required]
        [Range(0,5,ErrorMessage ="Please Enter between 1 & 5")]
        public int BHK { get; set; }

        [Range(100,5000,ErrorMessage ="Please enter area between 100 & 5000")]
        public double Area { get; set; }
        public bool IsRented { get; set; }

        public int SocietyId { get; set; }
    }
}