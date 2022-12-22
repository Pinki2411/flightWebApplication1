using flightWebApplication1.Models;
using flightWebApplication1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace flightWebApplication1.Controllers
{
    public class RegistrationController : Controller
    {

        private Ifunction<Registration> interfaceRobj = null;
        public RegistrationController()
        {
            this.interfaceRobj = new RepositoryClass<Registration>();
        }
        public RegistrationController(Ifunction<Registration> interfaceRobj)
        {
            this.interfaceRobj = interfaceRobj;
        }
        // GET: Registration

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginM(string email, string password)
        {
            if (ModelState.IsValid == true)
            {
                var user = interfaceRobj.GetModel().Where(model => model.Email == email && model.Password == password).FirstOrDefault();
                if (user == null)
                {
                    //Response.Write("<script>alert('Invalid Username or Password')</script>");
                    // ViewBag.ErrorMessage("Login Failed !!!  Enter your Credentials Again....");
                    return RedirectToAction("Login", "Registration");
                }
                else
                {
                    Session["UserName"] = email;
                    return RedirectToAction("Search", "Flight");

                }
            }
            else

                return RedirectToAction("Login", "Registration");
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Insert(Registration a)
        {
            if (ModelState.IsValid == true)
            {
                interfaceRobj.InsertModel(a);
                Session["UserName"] = a.Email;

                return RedirectToAction("Search", "Flight");
            }
            else
                return RedirectToAction("Create", "Registration");
        }

        public ActionResult SignUp()
        {
            return View();


        }

    }

} 

                
            
        
   