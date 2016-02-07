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

namespace FlowswitchApplication.Controllers
{
    [Authorize]
    public class CalibrationRecordController : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: CalibrationRecord
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "DateAdded" : "Date";
            ViewBag.TechnicianIDSortParm = String.IsNullOrEmpty(sortOrder) ? "TechnicianID" : "";
            ViewBag.FlowswitchIDSortParm = String.IsNullOrEmpty(sortOrder) ? "FlowswitchID" : "";
            

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var calibrationRecords = db.CalibrationRecords.Include(c => c.Technician).Include(c => c.Flowswitch).Include(c => c.ServiceRequest);
            if (!String.IsNullOrEmpty(searchString))
            {
                calibrationRecords = calibrationRecords.Where(c => c.Technician.FirstName.Contains(searchString)
                                       || c.Technician.LastName.Contains(searchString)
                                       || c.Technician.Username.Contains(searchString)
                                       || c.Flowswitch.Name.Contains(searchString)
                                       || c.Note.Contains(searchString)
                                       || c.ServiceRequest.Cater.Contains(searchString)
                                       || c.ServiceRequest.FamisWorkOrder.Contains(searchString));
                                       
            }

            switch (sortOrder)
            {
                case "DateAdded":
                    calibrationRecords = calibrationRecords.OrderByDescending(c => c.DateAdded);
                    break;
                case "TechnicianID":
                    calibrationRecords = calibrationRecords.OrderByDescending(c => c.TechnicianID);
                    break;
                case "FlowswitchID":
                     calibrationRecords = calibrationRecords.OrderByDescending(c => c.FlowswitchID);
                    break;
                default:
                    calibrationRecords = calibrationRecords.OrderByDescending(c => c.DateAdded);
                    break;

            }


            int pageSize = 60;
            int pageNumber = (page ?? 1);
            return View(calibrationRecords.ToPagedList(pageNumber, pageSize));
        }
        // GET: CalibrationRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibrationRecord calibrationRecord = db.CalibrationRecords.Find(id);
            if (calibrationRecord == null)
            {
                return HttpNotFound();
            }
            //return View(calibrationRecord);
            return PartialView("_Details",calibrationRecord);
        }

        // GET: CalibrationRecord/Create
        public ActionResult Create(int? flowswitchID)
        {
            if (flowswitchID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flowswitch flowswitches = db.Flowswitches.Find(flowswitchID);
            ViewBag.ID = flowswitchID;
            ViewBag.Name = flowswitches.Name;


            ViewBag.FlowswitchID = flowswitchID;// new SelectList(db.Flowswitches, "ID", "Name");
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ID", "FamisWorkOrder");
            ViewBag.TechnicianID = new SelectList(db.Technicians, "ID", "LastName");
            //return View();
            return PartialView("_Create");
        }

        // POST: CalibrationRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( int? flowswitchID,[Bind(Include = "ID,MaxInches,MaxGallons,TripInches,TripGallons,TechnicianID,DateAdded,FlowswitchID,Note,ServiceRequestID")] CalibrationRecord calibrationRecord)
        {
            if (ModelState.IsValid)
            {
                db.CalibrationRecords.Add(calibrationRecord);
                db.SaveChanges();
                return RedirectToAction("Details", "Flowswitch", new { id = flowswitchID});
                //return Json(new { success = true });
            }

            ViewBag.FlowswitchID = flowswitchID;// new SelectList(db.Flowswitches, "ID", "Name", calibrationRecord.FlowswitchID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ID", "FamisWorkOrder", calibrationRecord.ServiceRequestID);
            ViewBag.TechnicianID = new SelectList(db.Technicians, "ID", "LastName", calibrationRecord.TechnicianID);
            //return View(calibrationRecord);
            return PartialView("_Create", calibrationRecord);
        }

        // GET: CalibrationRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibrationRecord calibrationRecord = db.CalibrationRecords.Find(id);
            if (calibrationRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name", calibrationRecord.FlowswitchID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ID", "FamisWorkOrder", calibrationRecord.ServiceRequestID);
            ViewBag.TechnicianID = new SelectList(db.Technicians, "ID", "LastName", calibrationRecord.TechnicianID);
            return View(calibrationRecord);
        }

        // POST: CalibrationRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaxInches,MaxGallons,TripInches,TripGallons,TechnicianID,DateAdded,FlowswitchID,Note,ServiceRequestID")] CalibrationRecord calibrationRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calibrationRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Flowswitch", new { id = calibrationRecord.FlowswitchID });
            }
            ViewBag.FlowswitchID = new SelectList(db.Flowswitches, "ID", "Name", calibrationRecord.FlowswitchID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ID", "FamisWorkOrder", calibrationRecord.ServiceRequestID);
            ViewBag.TechnicianID = new SelectList(db.Technicians, "ID", "LastName", calibrationRecord.TechnicianID);
            return View(calibrationRecord);
        }

         //GET: CalibrationRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibrationRecord calibrationRecord = db.CalibrationRecords.Find(id);
            if (calibrationRecord == null)
            {
                return HttpNotFound();
            }
            return View("Delete", calibrationRecord);
        }

        //// POST: CalibrationRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalibrationRecord calibrationRecord = db.CalibrationRecords.Find(id);
            db.CalibrationRecords.Remove(calibrationRecord);
            db.SaveChanges();
            return RedirectToAction("Details", "Flowswitch", new { id = calibrationRecord.FlowswitchID });
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
