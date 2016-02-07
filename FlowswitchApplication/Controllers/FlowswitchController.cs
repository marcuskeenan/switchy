using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowswitchApplication.Models;
using PagedList;
using FlowswitchApplication.ViewModels;

namespace FlowswitchApplication.Controllers
{
   [Authorize]
    public class FlowswitchController : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: Flowswitch
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.AreaIDSortParm = String.IsNullOrEmpty(sortOrder) ? "AreaID" : "";
            ViewBag.LocationIDSortParm = String.IsNullOrEmpty(sortOrder) ? "LocationID" : "";
            ViewBag.SubsystemIDSortParm = String.IsNullOrEmpty(sortOrder) ? "SubsystemID" : "";
            ViewBag.WaterIDSortParm = String.IsNullOrEmpty(sortOrder) ? "WaterID" : "";
            ViewBag.SubsystemIDSortParm = String.IsNullOrEmpty(sortOrder) ? "SubsystemID" : "";
           
             
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var flowswitches = db.Flowswitches.Include(f => f.Area).Include(f => f.FlowswitchMake).Include(f => f.FlowswitchModel).Include(f => f.Location).Include(f => f.SubSystem).Include(f => f.FlowswitchType).Include(f => f.Venturi).Include(f => f.WaterSource);
            if (!String.IsNullOrEmpty(searchString))
            {
                flowswitches = flowswitches.Where(f => f.Name.Contains(searchString)
                                       || f.Alias.Contains(searchString)
                                       || f.Area.Area1.Contains(searchString)
                                       || f.Location.Location1.Contains(searchString)
                                       || f.SubSystem.Acronym.Contains(searchString)
                                       || f.WaterSource.Source.Contains(searchString));
            }
           
            
            switch (sortOrder)
            {
                case "Name":
                    flowswitches = flowswitches.OrderByDescending(f => f.Name);
                    break;
                case "AreaID":
                    flowswitches = flowswitches.OrderByDescending(f => f.AreaID);
                    break;
                case "LocationID":
                    flowswitches = flowswitches.OrderByDescending(f => f.LocationID);
                    break;
                case "SubsystemID":
                    flowswitches = flowswitches.OrderByDescending(f => f.SubsystemID);
                    break;
                case "WaterID":
                    flowswitches = flowswitches.OrderByDescending(f => f.WaterID);
                    break;
                default:
                    flowswitches = flowswitches.OrderBy(f => f.ID);
                    break;

            }


            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(flowswitches.ToPagedList(pageNumber, pageSize));
        }

        // GET: Flowswitch/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flowswitch flowswitches = db.Flowswitches.Find(id);
            if (flowswitches == null)
            {
                return HttpNotFound();
            }
            return View(flowswitches);

            //string flowswitchString = id.ToString();
           // String query = "SELECT COUNT(ID) CalibrationRecords WHERE FlowswitchID ="+ flowswitches;
            //var data = db.Database.SqlQuery<CalibrationRecordGroup>(query);
            //ViewBag.CalibrationCount = data;
            
            
            //var result = db.Flowswitches.SqlQuery(query, id);

        }
        // GET: FlowswitchesController/Create
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
            //return View();
            return PartialView("_Create");
        }

        // POST: FlowswitchesController/Create
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
                //return RedirectToAction("Index");
                return Json(new { success = true });
            }

            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1", flowswitch.AreaID);
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make", flowswitch.FlowswitchMakeID);
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model", flowswitch.FlowswitchModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1", flowswitch.LocationID);
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym", flowswitch.SubsystemID);
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type", flowswitch.TypeID);
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type", flowswitch.VenturiID);
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source", flowswitch.WaterID);
            //return View(flowswitch);
            return PartialView("_Create", flowswitch);
        }
        // GET: Flowswitche/Edit/5
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
            //return View(flowswitch);
            return PartialView("_Edit");
            
        }

        // POST: Flowswitche/Edit/5
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
                //return RedirectToAction("Index");
                //return RedirectToAction("Details", "Flowswitch", new { id = flowswitch.ID });
                return Json(new { success = true });
            }
            
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Area1", flowswitch.AreaID);
            ViewBag.FlowswitchMakeID = new SelectList(db.FlowswitchMakes, "ID", "Make", flowswitch.FlowswitchMakeID);
            ViewBag.FlowswitchModelID = new SelectList(db.FlowswitchModels, "ID", "Model", flowswitch.FlowswitchModelID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Location1", flowswitch.LocationID);
            ViewBag.SubsystemID = new SelectList(db.SubSystems, "ID", "Acronym", flowswitch.SubsystemID);
            ViewBag.TypeID = new SelectList(db.FlowswitchTypes, "ID", "Type", flowswitch.TypeID);
            ViewBag.VenturiID = new SelectList(db.Venturis, "ID", "Type", flowswitch.VenturiID);
            ViewBag.WaterID = new SelectList(db.WaterSources, "ID", "Source", flowswitch.WaterID);
            //return View(flowswitch);
            return PartialView("_Edit", flowswitch);
            
        }

        // GET: Flowswitche/Delete/5
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

        // POST: Flowswitche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flowswitch flowswitch = db.Flowswitches.Find(id);
            db.Flowswitches.Remove(flowswitch);
            db.SaveChanges();
            return RedirectToAction("Details", "Flowswitch", new { id = flowswitch.ID });
        }

        // GET: CalibrationRecord/Count
        public ActionResult CalibrationRecordCount(int? id)
        {

            var count = db.CalibrationRecords.Count(p => p.FlowswitchID == id);
            db.Dispose();
            return PartialView(count);
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
