using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;


namespace flightWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Guest()
        {
           
            return View();
        }
    }
}