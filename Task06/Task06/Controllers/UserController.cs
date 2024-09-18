using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task06.Models;

namespace Task06.Controllers
{
    public class UserController : Controller


    {

        PreProjectEntities db = new PreProjectEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(OurUser newUser, string confirmpassword)
        {
            if (ModelState.IsValid && newUser.password == confirmpassword)
            {
                db.OurUsers.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newUser);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(OurUser newUser)
        {
            var checkInputs = db.OurUsers.Where(model => model.email == newUser.email && model.password == newUser.password).FirstOrDefault();


            Session["UserID"] = checkInputs.id;

            if (checkInputs != null)
            {
               
                return RedirectToAction("Index");
            }

            else
            {
                ViewBag.errorMsg = "Email or Password is wrong!";
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Profile()
        {
            var userID = (int)Session["UserID"];
            var user = db.OurUsers.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(OurUser newUser, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
              

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                upload.SaveAs(path);
                newUser.image = fileName;
                Session["Image"] = fileName;
            }

            db.Entry(newUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Profile");
        }

        public ActionResult ResetPasswordt()
        {
            var userID = (int)Session["UserID"];
            var user = db.OurUsers.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordt(string currentPassword, string newPassword, string confirmNewPassword)
        {
            var userID = (int)Session["UserID"];
            var user = db.OurUsers.Find(userID);

            if (currentPassword == user.password)
            {
                if (newPassword == confirmNewPassword)
                {
                    user.password = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Message = "New Password does not match Confirm Password!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "Current Password is incorrect!";
                return View(user);
            }
        }



    }
}