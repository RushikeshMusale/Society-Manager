using SocietyManager.Data;
using SocietyManager.Models.SocietyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocietyManager.Controllers.SocietyControllers
{
    [Authorize(Roles ="Admin")]
    public class SocietyController : Controller
    {
        SocietyMaintenanceEntities1 db = new SocietyMaintenanceEntities1();
        // GET: Society
        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult RegisterSociety()
        {
            SocietyDetailsModel sd = new SocietyDetailsModel();
            return View(sd);
                
        }

        [HttpPost]
        public ActionResult RegisterSociety(SocietyDetailsModel model)
        {
            //Method to save image
            return View();

        }

    }
}