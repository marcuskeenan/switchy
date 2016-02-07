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
    public class FlowswitchesControllerTEST : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: FlowswitchesControllerTEST
        public ActionResult Index()
        {
            var flowswitches = db.Flowswitches.Include(f => f.Area).Include(f => f.FlowswitchMake).Include(f => f.FlowswitchModel).Include(f => f.Location).Include(f => f.SubSystem).Include(f => f.FlowswitchType).Include(f => f.Venturi).Include(f => f.WaterSource);
            return View(flowswitches.ToList());
        }

        // GET: FlowswitchesControllerTEST/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flowswitch flowswitch = db.Flowswitches.Find(id);
            if (flowswitch == null)
            {
                return HttpNotFound();
            }
            return View(flowswitch);
        }

        // GET: FlowswitchesControllerTEST/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1");
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make");
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model");
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1");
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym");
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type");
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type");
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source");
            return View();
        }

        // POST: FlowswitchesControllerTEST/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AreaID,LocationID,VenturiID,WaterID,SubsystemID,TypeID,DetailID,Name,Alias,FlowswitchMakeID,FlowswitchModelID")] Flowswitch flowswitch)
        {
            if (ModelState.IsValid)
            {
                db.Flowswitches.Add(flowswitch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1", flowswitch.AreaID);
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make", flowswitch.FlowswitchMakeID);
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model", flowswitch.FlowswitchModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1", flowswitch.LocationID);
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym", flowswitch.SubsystemID);
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type", flowswitch.TypeID);
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type", flowswitch.VenturiID);
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source", flowswitch.WaterID);
            return View(flowswitch);
        }

        // GET: FlowswitchesControllerTEST/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flowswitch flowswitch = db.Flowswitches.Find(id);
            if (flowswitch == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1", flowswitch.AreaID);
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make", flowswitch.FlowswitchMakeID);
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model", flowswitch.FlowswitchModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1", flowswitch.LocationID);
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym", flowswitch.SubsystemID);
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type", flowswitch.TypeID);
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type", flowswitch.VenturiID);
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source", flowswitch.WaterID);
            return View(flowswitch);
        }

        // POST: FlowswitchesControllerTEST/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AreaID,LocationID,VenturiID,WaterID,SubsystemID,TypeID,DetailID,Name,Alias,FlowswitchMakeID,FlowswitchModelID")] Flowswitch flowswitch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowswitch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1", flowswitch.AreaID);
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make", flowswitch.FlowswitchMakeID);
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model", flowswitch.FlowswitchModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1", flowswitch.LocationID);
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym", flowswitch.SubsystemID);
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type", flowswitch.TypeID);
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type", flowswitch.VenturiID);
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source", flowswitch.WaterID);
            return View(flowswitch);
        }

        // GET: FlowswitchesControllerTEST/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flowswitch flowswitch = db.Flowswitches.Find(id);
            if (flowswitch == null)
            {
                return HttpNotFound();
            }
            return View(flowswitch);
        }

        // POST: FlowswitchesControllerTEST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flowswitch flowswitch = db.Flowswitches.Find(id);
            db.Flowswitches.Remove(flowswitch);
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
