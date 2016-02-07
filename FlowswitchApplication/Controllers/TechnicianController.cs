using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowswitchApplication.Models;

namespace FlowswitchApplication.Controllers
{
    [Authorize]
    public class TechnicianController : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: Technician
        public ActionResult Index(string sortOrder)
        {
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
            //ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName" : "";
            //ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "Username" : "";
            var technicians = from t in db.Technicians
                           select t;
            switch (sortOrder)
            {
                case "LastName":
                    technicians = technicians.OrderBy(t => t.LastName);
                    break;
                case "FirstName":
                    technicians = technicians.OrderByDescending(t => t.FirstName);
                    break;
                case "Username":
                    technicians = technicians.OrderByDescending(t => t.Username);
                    break;
                default:
                    technicians = technicians.OrderByDescending(t => t.LastName);
                    break;
            }
            return View(db.Technicians.ToList());
        }

        // GET: Technician/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            return View(technician);
        }

        // GET: Technician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Username,Active")] Technician technician)
        {
            if (ModelState.IsValid)
            {
                db.Technicians.Add(technician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technician);
        }

        // GET: Technician/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            return View(technician);
        }

        // POST: Technician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Username,Active")] Technician technician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technician);
        }

        // GET: Technician/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            return View(technician);
        }

        // POST: Technician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technician technician = db.Technicians.Find(id);
            db.Technicians.Remove(technician);
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
