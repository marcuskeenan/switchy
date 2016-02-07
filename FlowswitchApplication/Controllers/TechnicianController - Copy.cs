using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowswitchApplication.Models;
using PagedList;

namespace FlowswitchApplication.Controllers
{
   // [Authorize]
    public class TechnicianController : Controller
    {
        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        // GET: Technician
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName" : "";
            ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "UserName" : "";
            ViewBag.ActiveSortParm = String.IsNullOrEmpty(sortOrder) ? "Active" : "";
          

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var technicians = db.Technicians.Include(t => t.FirstName).Include(t => t.Username).Include(t => t.Active);
            if (!String.IsNullOrEmpty(searchString))
            {
               technicians = technicians.Where(t => t.LastName.Contains(searchString)
                                       || t.FirstName.Contains(searchString)
                                       || t.Username.Contains(searchString));
                                      
                                       
            }
            
          
            switch (sortOrder)
            {
                case "LastName":
                    technicians = technicians.OrderByDescending(t => t.LastName);
                    break;
                case "FirstName":
                    technicians = technicians.OrderByDescending(t => t.FirstName);
                    break;
                case "UserName":
                    technicians = technicians.OrderByDescending(t => t.Username);
                    break;
                case "Active":
                    technicians = technicians.OrderByDescending(t => t.Active);
                    break;
                default:
                    technicians = technicians.OrderBy(t => t.LastName);
                    break;

            }


            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(technicians.ToPagedList(pageNumber, pageSize));
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
