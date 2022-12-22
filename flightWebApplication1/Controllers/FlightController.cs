using flightWebApplication1.Models;
using flightWebApplication1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace flightWebApplication1.Controllers
{
    public class FlightController : Controller
    {
        private Ifunction<Flight> interfaceobj = null ;
        public FlightController()
        {
            this.interfaceobj = new RepositoryClass<Flight>();
        }
        public FlightController(Ifunction<Flight> interfaceobj)
        {
            this.interfaceobj = interfaceobj;
        }
            public ActionResult Index()
            {
                Session["Guest"] = true;
                return RedirectToAction("Search", "Flight");
            }

        public ActionResult Search()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchResult(Flight ft)
        {
            var th = ft.DateAndTime.Date;
            var data = interfaceobj.GetModel().Where(x => (x.DateAndTime.Date ==th) && (x.To == ft.To) && (x.From == ft.From));
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Flight obj)
        {
            try
            {
                interfaceobj.InsertModel(obj);
                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
           interfaceobj.DeleteModel(id);
           return RedirectToAction("Search");
        }
    }
}