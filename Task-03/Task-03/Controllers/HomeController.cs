using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Loggedin"] = "0";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(FormCollection form, string[] food)
        {
            //ViewBag.Message = "Your contact page.";
            string email = form["email"];
            string city = form["selectcity"];
            food = form.GetValues("selectfood");
            string feedback = form["feedback"];

            ViewBag.Email = email;
            ViewBag.City = city;
            ViewBag.Feedback = feedback;
            ViewBag.Food = food;


            return View();
        }

        public ActionResult Login(FormCollection form)
        {

            string[] userData = { "mfawarah1@gmail.com", "2016975037" };
            string email = form["email"];
            string password = form["password"];

            if (email == userData[0] && password == userData[1])
            {
                Session["Loggedin"] = "1";
                return View("Index");
                
            }
            else
            {
                Session["Loggedin"] = "0";
                return View();
            }


        }

  
    }
}