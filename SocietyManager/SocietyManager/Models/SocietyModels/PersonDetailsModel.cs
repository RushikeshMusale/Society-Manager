using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocietyManager.Models.SocietyModels
{
    public class PersonDetailsModel
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CurrentAddress { get; set; }

        [Required]
        public string PermanantAddress { get; set; }

        [Required]
        [StringLength(10, MinimumLength =10)]
        public string MobileNumber { get; set; }
    }
}