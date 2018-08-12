﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodFinder.Models;

namespace FoodFinder.Controllers
{
    public class SupermarketsController : Controller
    {
        private FoodFinderContextEntities db = new FoodFinderContextEntities();

        // GET: Supermarkets
        public ActionResult Index()
        {
            return View(db.Supermarkets.ToList());
        }

        // GET: Supermarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermarket supermarket = db.Supermarkets.Find(id);
            if (supermarket == null)
            {
                return HttpNotFound();
            }
            return View(supermarket);
        }

        // GET: Supermarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supermarkets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreID,StoreName")] Supermarket supermarket)
        {
            if (ModelState.IsValid)
            {
                db.Supermarkets.Add(supermarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supermarket);
        }

        // GET: Supermarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermarket supermarket = db.Supermarkets.Find(id);
            if (supermarket == null)
            {
                return HttpNotFound();
            }
            return View(supermarket);
        }

        // POST: Supermarkets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreID,StoreName")] Supermarket supermarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supermarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supermarket);
        }

        // GET: Supermarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermarket supermarket = db.Supermarkets.Find(id);
            if (supermarket == null)
            {
                return HttpNotFound();
            }
            return View(supermarket);
        }

        // POST: Supermarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supermarket supermarket = db.Supermarkets.Find(id);
            db.Supermarkets.Remove(supermarket);
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
