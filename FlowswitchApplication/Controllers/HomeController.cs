using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowswitchApplication.ViewModels;
using FlowswitchApplication.Models;

namespace FlowswitchApplication.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {

        private flowswitch_dbEntities db = new flowswitch_dbEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            string query = "SELECT Technicians.LastName, COUNT(CalibrationRecords.ID) AS CalibrationCount "
                + "FROM Technicians, CalibrationRecords "
                + "WHERE Technicians.ID = CalibrationRecords.TechnicianID "
                + "GROUP BY Technicians.LastName "
                + "ORDER BY COUNT(CalibrationRecords.ID) DESC ";
            IEnumerable<CalibrationTechnicianGroup> data = db.Database.SqlQuery<CalibrationTechnicianGroup>(query);
            return View(data.ToList());
      }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: Flowswitch/Count
        public ActionResult FlowswitchCount()
        {

            var count = db.Flowswitches.Count();
            db.Dispose();
            return PartialView(count);
        }

        // GET: CalibrationRecord/Count
        public ActionResult CalibrationRecordCount()
        {

            var count = db.CalibrationRecords.Count();
            db.Dispose();
            return PartialView(count);
        }

        public ActionResult BadActor()
        {

            //string query = "SELECT TOP 100 Flowswitches.Name, COUNT(CalibrationRecords.ID) AS CalibrationCount "
            //    + "FROM Flowswitches, CalibrationRecords "
            //    + "WHERE Flowswitches.ID = CalibrationRecords.FlowswitchID "
            //    + "GROUP BY Flowswitches.Name "
            //    + "ORDER BY COUNT(CalibrationRecords.ID) DESC ";
            //IEnumerable<CalibrationFlowswitchGroup> data = db.Database.SqlQuery<CalibrationFlowswitchGroup>(query);
            //return View(data.ToList());
            string query = "SELECT TOP 100 ROW_NUMBER() OVER (ORDER BY COUNT(CalibrationRecords.ID) DESC) AS Row,Flowswitches.Name, COUNT(CalibrationRecords.ID) AS CalibrationCount "
                + "FROM Flowswitches, CalibrationRecords "
                + "WHERE Flowswitches.ID = CalibrationRecords.FlowswitchID "
                + "GROUP BY Flowswitches.Name "
                + "ORDER BY COUNT(CalibrationRecords.ID) DESC ";
            IEnumerable<CalibrationFlowswitchGroup> data = db.Database.SqlQuery<CalibrationFlowswitchGroup>(query);
            return View(data.ToList());
        }

        public ActionResult ViewLyubomir()
        {
            return PartialView("_Lyubomir");
        }

        [HttpPost]
        public ActionResult Lyubomir()
        {
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}