using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data.Entity; // u need to add this for the edit
using messup02_28_7.Models; //u should add this


namespace messup02_28_7.Controllers
{
    public class UserController : Controller
    {

        TheUsersEntities db = new TheUsersEntities();
        // GET: User
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        //Get >> Create
        public ActionResult Create()
        {
            return View();

        }

        //Post >> Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user newUser)
        {

            if (ModelState.IsValid)
            {

                db.users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUser);

        }


        //Get >> Edit/update
        public ActionResult Edit(int id = 0)
        {

            user newUser = db.users.Find(id);
            if (newUser == null)
            {
                return HttpNotFound();
            }
            return View(newUser);
        }

        //Post >> Edit/update

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(user newUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View (newUser);
        }


        //Get >> Delete

        public ActionResult Delete(int id)
        {

            user newUser = db.users.Find(id);

            if (newUser == null)
            {
                return HttpNotFound();
            }
            return View(newUser);
        }

        //Post >> Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            user newUser = db.users.Find(id);
            db.users.Remove(newUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Get >> details
        public ActionResult details(int id) {

            user newUser = db.users.Find(id);

            if (newUser == null)
            {
                return HttpNotFound();
            }

            return View(newUser);
        
        }

        protected override void Dispose (bool disposing)
        {

            db.Dispose();
            base.Dispose (disposing);
        } 



    }
}