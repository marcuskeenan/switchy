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
    public class FlowswitchNotesController : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: FlowswitchNotes
        public ActionResult Index()
        {
            var flowswitchNotes = db.FlowswitchNotes.Include(f => f.Flowswitch);
            return View(flowswitchNotes.ToList());
        }

        // GET: FlowswitchNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowswitchNote flowswitchNote = db.FlowswitchNotes.Find(id);
            if (flowswitchNote == null)
            {
                return HttpNotFound();
            }
            return View(flowswitchNote);
        }

        // GET: FlowswitchNotes/Create
        public ActionResult Create()
        {
            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name");
            return View();
        }

        // POST: FlowswitchNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDold,Note,FlowswitchID,TechnicianID,DateAdded")] FlowswitchNote flowswitchNote)
        {
            if (ModelState.IsValid)
            {
                db.FlowswitchNotes.Add(flowswitchNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name", flowswitchNote.FlowswitchID);
            return View(flowswitchNote);
        }

        // GET: FlowswitchNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowswitchNote flowswitchNote = db.FlowswitchNotes.Find(id);
            if (flowswitchNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name", flowswitchNote.FlowswitchID);
            return View(flowswitchNote);
        }

        // POST: FlowswitchNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDold,Note,FlowswitchID,TechnicianID,DateAdded")] FlowswitchNote flowswitchNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowswitchNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name", flowswitchNote.FlowswitchID);
            return View(flowswitchNote);
        }

        // GET: FlowswitchNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowswitchNote flowswitchNote = db.FlowswitchNotes.Find(id);
            if (flowswitchNote == null)
            {
                return HttpNotFound();
            }
            return View(flowswitchNote);
        }

        // POST: FlowswitchNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowswitchNote flowswitchNote = db.FlowswitchNotes.Find(id);
            db.FlowswitchNotes.Remove(flowswitchNote);
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
