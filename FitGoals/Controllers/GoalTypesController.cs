using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitGoals.Models;

namespace FitGoals.Controllers
{
    public class GoalTypesController : Controller
    {
        private FitGoalsEntities db = new FitGoalsEntities();

        // GET: GoalTypes
        public ActionResult Index()
        {
            return View(db.GoalTypes.ToList());
        }

        // GET: GoalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalType goalType = db.GoalTypes.Find(id);
            if (goalType == null)
            {
                return HttpNotFound();
            }
            return View(goalType);
        }

        // GET: GoalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoalTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoalTypeID,GoalName")] GoalType goalType)
        {
            if (ModelState.IsValid)
            {
                db.GoalTypes.Add(goalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goalType);
        }

        // GET: GoalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalType goalType = db.GoalTypes.Find(id);
            if (goalType == null)
            {
                return HttpNotFound();
            }
            return View(goalType);
        }

        // POST: GoalTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoalTypeID,GoalName")] GoalType goalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goalType);
        }

        // GET: GoalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalType goalType = db.GoalTypes.Find(id);
            if (goalType == null)
            {
                return HttpNotFound();
            }
            return View(goalType);
        }

        // POST: GoalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoalType goalType = db.GoalTypes.Find(id);
            db.GoalTypes.Remove(goalType);
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
