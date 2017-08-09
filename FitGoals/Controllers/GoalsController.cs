using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitGoals.Models;
using Microsoft.AspNet.Identity;

namespace FitGoals.Controllers
{
    public class GoalsController : Controller
    {
        private FitGoalsEntities db = new FitGoalsEntities();

        // GET: Goals
        public ActionResult Index()
        {
            var goals = db.Goals.Include(g => g.GoalType).Include(g => g.Measurement);
            return View(goals.ToList());
        }

        // GET: Goals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // GET: Goals/Create
        public ActionResult Create()
        {
            ViewBag.GoalTypeID = new SelectList(db.GoalTypes, "GoalTypeID", "GoalName");
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName");
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoalID,GoalName,GoalTypeID,GoalQuantity,MeasurementID,GoalDeadline,UserAssociation")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                goal.UserAssociation = User.Identity.GetUserId();
                db.Goals.Add(goal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoalTypeID = new SelectList(db.GoalTypes, "GoalTypeID", "GoalName", goal.GoalTypeID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", goal.MeasurementID);
            return View(goal);
        }

        // GET: Goals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoalTypeID = new SelectList(db.GoalTypes, "GoalTypeID", "GoalName", goal.GoalTypeID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", goal.MeasurementID);
            return View(goal);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoalID,GoalName,GoalTypeID,GoalQuantity,MeasurementID,GoalDeadline,UserAssociation")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoalTypeID = new SelectList(db.GoalTypes, "GoalTypeID", "GoalName", goal.GoalTypeID);
            ViewBag.MeasurementID = new SelectList(db.Measurements, "MeasurementID", "MeasurementName", goal.MeasurementID);
            return View(goal);
        }

        // GET: Goals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goal goal = db.Goals.Find(id);
            db.Goals.Remove(goal);
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
