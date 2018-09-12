using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Falcorp.Timesheets.Controllers
{
    using Api;
    using Models;
    using Timesheet.DAL.Api;
    using Timesheet.DAL.EF;
    using Timesheets;
    using Web.Components.UI;


    /// <summary>
    /// 
    /// </summary>
    public class EmployeeTimesController : BaseController
    {
        private TimeSheetsEntities1 db = new TimeSheetsEntities1();
        protected TimeSheetRepositoryStore dbStore = new TimeSheetRepositoryStore();
        private UIComponentManager _uiToolbox = new UIComponentManager();

        // GET: EmployeeTimes
        public ActionResult Index()
        {
            var model = new CaptureViewModel
            {
                AllocatedProject = _uiToolbox.Form.MultiSelector<EmployeeAllocatedProjects_Result>(null, dbStore.ProjectRepositoryStore.AllocatedProjects(EmployeeId).ToList(), "Id" , "Name")
            };

            return View(model);
        }

        // GET: EmployeeTimes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTime employeeTime = db.EmployeeTimes.Find(id);
            if (employeeTime == null)
            {
                return HttpNotFound();
            }
            return View(employeeTime);
        }

        // GET: EmployeeTimes/Create
        public ActionResult Create(Guid id)
        {
            var employeeModel = db.Employees
                .Where(c => c.EmployeeID == id)
                .SingleOrDefault();
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName","FirstName");
            return View(
                new EmployeeTime
                {
                    Employee = employeeModel,
                    EmployeeID = employeeModel.EmployeeID,
                    //FirstName = employeeModel.FirstName
                });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeTimeID,CapturedDate,ChargableTime,ProjectCode,ProjectOwner,Client,EmployeeID,TotalBillableHours,OverTimeHours,Comments")] EmployeeTime employeeTime)
        {
            var employeeModel = db.Employees
                .Where(c => c.EmployeeID == employeeTime.EmployeeID)
                .SingleOrDefault();
            if (ModelState.IsValid)
            {
                var capture = new EmployeeTime
                {
                    EmployeeID = employeeTime.EmployeeID,
                    CapturedDate = employeeTime.CapturedDate,
                    TotalBillableHours = employeeTime.TotalBillableHours,
                    ChargableTime = employeeTime.ChargableTime,
                    ProjectCode = employeeTime.ProjectCode,
                    ProjectOwner = employeeTime.ProjectOwner,
                    Comments = employeeTime.Comments,
                    Client = employeeTime.Client//,
                   // OverTimeHours = employeeTime.OverTimeHours,

                };
               // employeeTime.EmployeeTimeID = Guid.NewGuid();
                db.EmployeeTimes.Add(capture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", employeeTime.EmployeeID);
            return View(employeeTime);
        }

        // GET: EmployeeTimes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTime employeeTime = db.EmployeeTimes.Find(id);
            if (employeeTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", employeeTime.EmployeeID);
            return View(employeeTime);
        }

        // POST: EmployeeTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeTimeID,CapturedDate,ChargableTime,ProjectCode,ProjectOwner,Client,EmployeeID,TotalBillableHours,Comments")] EmployeeTime employeeTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", employeeTime.EmployeeID);
            return View(employeeTime);
        }

        // GET: EmployeeTimes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTime employeeTime = db.EmployeeTimes.Find(id);
            if (employeeTime == null)
            {
                return HttpNotFound();
            }
            return View(employeeTime);
        }

        // POST: EmployeeTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EmployeeTime employeeTime = db.EmployeeTimes.Find(id);
            db.EmployeeTimes.Remove(employeeTime);
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
