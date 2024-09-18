using _29_7_task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _29_7_task.Controllers
{
    public class ouruserController : Controller


    {

        private PreProjectEntities db = new PreProjectEntities();

        // GET: ouruser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register([Bind(Include = "id, email,, password, confirmpassword")] OurUser newUser)
        {
            if (ModelState.IsValid && (newUser.password == newUser.confirmpassword))
            {

                db.OurUsers.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(newUser);
        }





        //----------------- Login -----------------------------------


        public ActionResult Login()
        {

            return View();


        }

        [HttpPost]
        public ActionResult Login(OurUser newUser)
        {

            var check = db.OurUsers.Where(model => model.email == newUser.email && model.password == newUser.password);
            if (check != null)
            {

                Session["LoggedIn"] = newUser.email;
                return View("Index");

            }
            return View();


        }

        public ActionResult Profile() {
            PreProjectEntities db = new PreProjectEntities();
            string userEmail = Session["LoggedIn"].ToString();

            //find the user by email
            var user = db.OurUsers.FirstOrDefault(u => u.email == userEmail);
            return View(user);
        
        }

        public ActionResult Logout()
        {
           

            Session.Clear();
            return RedirectToAction("Index");

        }



        public ActionResult Edit(int? id)
        {
            OurUser user = db.OurUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Password")] OurUser user, HttpPostedFileBase upload)
        {


            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                user.image = fileName;
            }

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
