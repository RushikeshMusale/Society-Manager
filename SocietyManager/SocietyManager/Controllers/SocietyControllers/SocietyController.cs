using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocietyManager.Controllers.SocietyControllers
{
    public class SocietyController : Controller
    {
        // GET: Society
        public ActionResult Index()
        {
            return View();
        }
    }
}