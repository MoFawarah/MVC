using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing.Controllers
{
    public class UserController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult Enquires()
        {
            return View();

        }

        public ActionResult BookTour()
        {
            return View();

        }

        public ActionResult PathDesign()
        {
            return View();

        }

        public ActionResult About()
        {
            return View();

        }

        public ActionResult Contact()
        {
            return View();

        }
    }
}