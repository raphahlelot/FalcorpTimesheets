using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Falcorp.Timesheets.Controllers
{

    using Api;
    using Timesheets;
    using Models;
    using Timesheet.DAL.Api;


    [Authorize]
    public class HomeController : BaseController
    {
        public TimeSheetsEntities1 db = new TimeSheetsEntities1();

        protected TimeSheetRepositoryStore dbStore = new TimeSheetRepositoryStore();

        [HttpGet]
        public async Task<ActionResult> Index()
        {

            Session["CurrentBill"] =  string.Concat(dbStore.MonthlyProgressReportStore.ChargeableMonth, " " , dbStore.MonthlyProgressReportStore.ChargeableYear);

            var model = new HomeViewModel
            {
                EstimatedBillableHours =  dbStore.MonthlyProgressReportStore.MonthlyProgress(EmployeeId),

                Project                =  dbStore.ProjectRepositoryStore.HighestAllocatedProject(EmployeeId),

                Projects               =  dbStore.ProjectRepositoryStore.AllocatedProjects(EmployeeId)

            };


            return View(model);
        }

        [HttpGet]
        public ActionResult CaptureTime(Guid id)
        {
            var EmployeeModel = db.Employees
                .Where(c => c.EmployeeID == id)
                .SingleOrDefault();
            return View(
                new CaptureViewModel
                {
                    employee = EmployeeModel,
                    EmployeeId = EmployeeModel.EmployeeID,
                    FirstName = EmployeeModel.FirstName,
                });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CaptureTime([Bind(Include = "EmployeeTimeID,EmployeeID,CapturedDate,TotalBillableHours,ChargableTime,ProjectCode,ProjectOwner,Comments,Client")]CaptureViewModel model)
        {
            var EmployeeModel = db.Employees
                .Where(c => c.EmployeeID == model.EmployeeId)
                .SingleOrDefault();
            if (ModelState.IsValid)
            {
                var capture = new EmployeeTime
                {
                    EmployeeID = model.EmployeeId,
                    CapturedDate = model.CapturedDate,
                    TotalBillableHours = model.TotalBillableHours,
                    ChargableTime = model.ChargeableTime,
                    ProjectCode = model.ProjectCode,
                    ProjectOwner = model.ProjectOwner,
                    Comments = model.Comments,
                    Client = model.Client,
                   // EmployeeTimeID = model.EmployeeTimeID
                };
                db.EmployeeTimes.Add(capture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
    }
}