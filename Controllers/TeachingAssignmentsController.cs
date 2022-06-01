using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicationEPAC.Models;

namespace AplicationEPAC.Controllers
{
    [Authorize(Roles = "admin")]
    public class TeachingAssignmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeachingAssignments
        public ActionResult Index()
        {
            var teachingAssignments = db.TeachingAssignments.Include(t => t.Course).Include(t => t.Group).Include(t => t.User);
            return View(teachingAssignments.ToList());
        }

        // GET: TeachingAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Year");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: TeachingAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CourseId,GroupId")] TeachingAssignments teachingAssignments)
        {
            if (ModelState.IsValid)
            {
                db.TeachingAssignments.Add(teachingAssignments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Year", teachingAssignments.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", teachingAssignments.GroupId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", teachingAssignments.UserId);
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Year", teachingAssignments.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", teachingAssignments.GroupId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", teachingAssignments.UserId);
            return View(teachingAssignments);
        }

        // POST: TeachingAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CourseId,GroupId")] TeachingAssignments teachingAssignments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachingAssignments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Year", teachingAssignments.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", teachingAssignments.GroupId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", teachingAssignments.UserId);
            return View(teachingAssignments);
        }

        // GET: TeachingAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            if (teachingAssignments == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignments);
        }

        // POST: TeachingAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeachingAssignments teachingAssignments = db.TeachingAssignments.Find(id);
            db.TeachingAssignments.Remove(teachingAssignments);
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
