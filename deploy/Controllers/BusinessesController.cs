using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using deploy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace deploy.Controllers
{
    public class BusinessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Businesses
        public ActionResult Index()
        {
            var businesses = db.Businesses.Include(b => b.BusinessType);
            return View(businesses.ToList());
        }

        // GET: Businesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // GET: Businesses/Create
      //  [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            ViewBag.BusinessTypeID = new SelectList(db.BusinessTypes, "BusinessTypeID", "BusinessTypeName");
            return View();
        }

        // POST: Businesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "BusinessID,BusinessName,BusinessTypeID,Address,Hours,Phone,Menu")] Business business)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var CurrentUser = UserManager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                business.ApplicationUser = CurrentUser;
                db.Businesses.Add(business);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessTypeID = new SelectList(db.BusinessTypes, "BusinessTypeID", "BusinessTypeName", business.BusinessTypeID);
            return View(business);
        }

        // GET: Businesses/Edit/5
        //[Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessTypeID = new SelectList(db.BusinessTypes, "BusinessTypeID", "BusinessTypeName", business.BusinessTypeID);
            return View(business);
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "BusinessID,BusinessName,BusinessTypeID,Address,Hours,Phone,Menu")] Business business)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var CurrentUser = UserManager.FindById(User.Identity.GetUserId());

            var oldBusiness = db.Businesses.Find(business.BusinessID);
            if (oldBusiness.ApplicationUser != CurrentUser)
            {
                return new HttpUnauthorizedResult();
            }
            if (ModelState.IsValid)
            {
                // db.Entry(business).State = EntityState.Modified;
                oldBusiness.BusinessName = business.BusinessName;
                oldBusiness.BusinessTypeID = business.BusinessTypeID;
                oldBusiness.Address = business.Address;
                oldBusiness.Hours = business.Hours;
                oldBusiness.Phone = business.Phone;
                oldBusiness.Menu = business.Menu;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessTypeID = new SelectList(db.BusinessTypes, "BusinessTypeID", "BusinessTypeName", business.BusinessTypeID);
            return View(business);
        }

        // GET: Businesses/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
      
        public ActionResult DeleteConfirmed(int id)
        {
            Business business = db.Businesses.Find(id);
            db.Businesses.Remove(business);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
