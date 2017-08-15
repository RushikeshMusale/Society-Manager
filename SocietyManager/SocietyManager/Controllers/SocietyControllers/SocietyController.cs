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
        SocietyMaintenanceEntities db = new SocietyMaintenanceEntities();
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
        //HttpPostedFileBase societyImage: this name should be same is inptu tag in view
        public ActionResult RegisterSociety(SocietyDetailsModel society)
        {
            if(society.testImage!=null)
            {
                society.SocietyImage = new byte[society.testImage.ContentLength];
                society.testImage.InputStream.Read(society.SocietyImage, 0, society.testImage.ContentLength);

                Society newsociety = new Society()
                {
                    Name=society.Name,
                    Address=society.Address,
                    BuilderName=society.Builder,
                    AccountNumber=society.AccountNumber,
                    TotalFlats=society.NumberOfFlats,
                    SocietyImage=society.SocietyImage,                    
                };

                db.Societies.Add(newsociety);
                db.SaveChanges();
            }
            //Method to save image
            return View();

        }

        public ActionResult GetSocietyDetail()
        {
            var sd = db.Societies.FirstOrDefault();
            SocietyDetailsModel sdmodel = new SocietyDetailsModel() {
                Name=sd.Name,
                Address=sd.Address,
                Builder=sd.BuilderName,
                AccountNumber=sd.AccountNumber,
                Id=sd.SocietyId,
                NumberOfFlats=sd.TotalFlats??0,              
                SocietyImage=sd.SocietyImage
            };

            return View(sdmodel);
        }          

    }
}