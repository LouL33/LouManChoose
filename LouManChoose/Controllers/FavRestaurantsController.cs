using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LouManChoose.Models;

namespace LouManChoose.Controllers
{
    public class FavRestaurantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FavRestaurants
        public ActionResult Index()
        {
            return View(db.Favorites.ToList());
        }

        // GET: FavRestaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavRestaurants favRestaurants = db.Favorites.Find(id);
            if (favRestaurants == null)
            {
                return HttpNotFound();
            }
            return View(favRestaurants);
        }

        // GET: FavRestaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavRestaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Address,UserId")] FavRestaurants favRestaurants)
        {
            if (ModelState.IsValid)
            {
                db.Favorites.Add(favRestaurants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favRestaurants);
        }

        // GET: FavRestaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavRestaurants favRestaurants = db.Favorites.Find(id);
            if (favRestaurants == null)
            {
                return HttpNotFound();
            }
            return View(favRestaurants);
        }

        // POST: FavRestaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Address,UserId")] FavRestaurants favRestaurants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favRestaurants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favRestaurants);
        }

        // GET: FavRestaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavRestaurants favRestaurants = db.Favorites.Find(id);
            if (favRestaurants == null)
            {
                return HttpNotFound();
            }
            return View(favRestaurants);
        }

        // POST: FavRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavRestaurants favRestaurants = db.Favorites.Find(id);
            db.Favorites.Remove(favRestaurants);
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
