using System;
using System.Web.Mvc;
using flightWebApplication1.Models;
using flightWebApplication1.Models.Repository;

namespace flightWebApplication1.Controllers
{
    public class CheckInController : Controller
    {
        flightContext db = new flightContext();
        private Ifunction<CheckIn> interfaceCObj = null;
        public CheckInController()
        {
            this.interfaceCObj = new RepositoryClass<CheckIn>();
        }
        public CheckInController(Ifunction<CheckIn> interfaceCObj)
        {
            this.interfaceCObj = interfaceCObj;
        }
        // GET: CheckIn
        public ActionResult CheckInId()
        {
         
            CheckIn ch = new CheckIn();
            ch.Booking_id = (int)Session["Bid"];
            Random s = new Random();
            int num = s.Next(1, 50);
            ch.Check_Id = num;
            Random r = new Random();
            int seat = r.Next(1, 60);
            ch.Seat_Allocation=seat;
            interfaceCObj.InsertModel(ch);
            ViewBag.ch = ch;   
            return View();
        }
       
    }
}