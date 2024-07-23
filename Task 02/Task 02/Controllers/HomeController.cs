using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitContact(string Name, string Phone, string Gender, string Country, string[] Hobbies)
        {
            ViewBag.Name = Name;
            ViewBag.Phone = Phone;
            ViewBag.Gender = Gender;
            ViewBag.Country = Country;
            ViewBag.Hobbies = Hobbies;

            return View("ContactResult");
        }

        public ActionResult ContactResult() { 
        return View();
        }
    }
}