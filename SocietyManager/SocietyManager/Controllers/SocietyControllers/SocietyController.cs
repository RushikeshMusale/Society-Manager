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

                Session["societyId"] = newsociety.SocietyId;
                Session["societyName"] = newsociety.Name;
            }
            //Method to save image
            return RedirectToAction("AddFlatDetails");

        }

        public ActionResult GetSocietyDetail(int id)
        {
            var sd = db.Societies.Single(x=>x.SocietyId==id);
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

        public ActionResult AddFlatDetails()
        {

            var societyid = (int) Session["societyId"];
           
            int numberOfFlats= (int)(from so in db.Societies
                                where so.SocietyId== societyid
                                select so.TotalFlats).FirstOrDefault();
            if(numberOfFlats>0)
            {
                FlatListsModel sfm = new FlatListsModel(numberOfFlats);
                return View(sfm);
            }
            else
            {
                //Society Id is not valid so send back to error page
                return View();
            }
            
        }

        [HttpPost]
        [ActionName("AddFlatDetails")]
        public ActionResult AddFlatDetails_post(FlatListsModel sfm, FormCollection forms)
        {
            if(ModelState.IsValid)
            {
                int societyId = (int)Session["societyId"];
                //code to add flats
                var flatLists= ( from flat in sfm.flatsInSociety
                select new Flat()
                {
                    SocietyId = societyId,
                    FlatNumber = flat.FlatNumber,
                    Area = flat.Area,
                    BHK = flat.BHK,
                    IsRented = flat.IsRented
                }).ToList();

                db.Flats.AddRange(flatLists);
                db.SaveChanges();
                return RedirectToAction("AddOwnerDetails");
            }
          
            return View(sfm);
        }


        public ActionResult AddOwnerDetails()
        {
            // int societyId = Session["societyId"]!=null ? (int)Session["societyId"]: -1;
            int societyId = (int)Session["societyId"];
            if (societyId != -1)
            {
                //Get number of flats in that society
                //int numberOfFlats = (int)(from so in db.Societies
                //                          where so.SocietyId == societyId
                //                          select so.TotalFlats).FirstOrDefault();

                var society = (from so in db.Societies
                               where so.SocietyId == societyId
                               select so).FirstOrDefault();

                if (society != null)
                {
                    int numberOfFlats = society.TotalFlats.Value;

                    //check if numberOfFlats is not null
                    string[] flatList = (from flat in society.Flats
                                         select flat.FlatNumber).ToArray();


                    //check flatList is not null
                    OwnerList ownerList = new OwnerList(numberOfFlats,flatList);
                    return View(ownerList);
                }
            }
            return View();
        }
    }
}