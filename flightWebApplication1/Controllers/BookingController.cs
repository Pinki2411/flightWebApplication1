using flightWebApplication1.Models.Repository;
using flightWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Security.Permissions;
using System.Numerics;

namespace flightWebApplication1.Controllers
{
    public class BookingController : Controller
    {
         flightContext db = new flightContext();
        private Ifunction<Booking> interfaceBObj = null;
        private Ifunction<Flight> interfaceFObj=null;
        private Ifunction<Registration> interfaceRObj = null;
        public BookingController()
        {
            this.interfaceBObj = new RepositoryClass<Booking>();
            this.interfaceFObj= new RepositoryClass<Flight>();  
            this.interfaceRObj= new RepositoryClass<Registration>();    
        }
        public BookingController(Ifunction<Booking> interfaceBObj)
        {
            this.interfaceBObj = interfaceBObj;
        }
        // GET: Booking
        public ActionResult Index()
        {
            var data = from m in interfaceBObj.GetModel() select m;
            return View(data);
        }

        public ActionResult CreateBOOK(int FLIGHTid)
        {
            //if (Session["guest"] == null)
           // {
                Session["FID"] = FLIGHTid;


                if (Session["Username"] == null)
                {
                    return RedirectToAction("Login", "Registration");
                }
                else
                {
                    ViewBag.data = interfaceFObj.GetModelbyID((int)Session["FID"]);
                    int seatno = (from i in db.dbsetflight where i.Flight_Id == FLIGHTid select i.seatAvailable).FirstOrDefault();
                    if (seatno != 0)//checking seat is avaiable or not
                        return View();
                    else
                    {
                        Response.Write("<script>alert('Not Avaiable Seat')</script>");
                        return RedirectToAction("Search", "Flight");
                    }
                }
            //}
           // else
               // return RedirectToAction("Login", "Registration");
  
        }
        [HttpPost]
        public ActionResult Create( Booking booking)
        {

            Guid guid = Guid.NewGuid();



            BigInteger big = new BigInteger(guid.ToByteArray());
            var rnum = big.ToString().Substring(0, 10);
            var str = rnum.Replace("-", string.Empty);

            Random s = new Random();
            Session["Rnum"] = s.Next(1,50);
            booking.ReferenceNo = (int)Session["Rnum"];
            booking.Flight_Id = (int)Session["FID"];
            booking.Email = (String)Session["UserName"];

            interfaceBObj.InsertModel(booking);

            return RedirectToAction("ConfirmBooking","Booking");
        }
        public ActionResult ConfirmBooking()
        {
            ViewBag.Message = " Booking Confirmed With Reference No.";
            
            return View();
        }
        public ActionResult SearchReference()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchReferenceP(int ReferenceNo)
        {
            
            Booking booking= new Booking();
            booking = (from i in db.bookings where i.ReferenceNo == ReferenceNo select i).FirstOrDefault();
            if (booking != null)
            {
                ViewBag.Passenger = booking;
                Session["Bid"] = booking.Booking_id;
                Flight FT = new Flight();
                FT = (from i in db.dbsetflight where i.Flight_Id == booking.Flight_Id select i).FirstOrDefault();
                ViewBag.flight = FT;
                return View();
            }
            else
                return HttpNotFound();
        }

    }
}