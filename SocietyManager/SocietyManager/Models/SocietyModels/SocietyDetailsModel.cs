using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManager.Models.SocietyModels
{
    public class SocietyDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Builder { get; set; }
        public string AccountNumber { get; set; }
        public int NumberOfFlats { get; set; }
        
    }
}