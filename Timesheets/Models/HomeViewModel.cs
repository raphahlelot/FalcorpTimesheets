using Falcorp.Timesheet.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Falcorp.Timesheets.Models
{

    public sealed partial class HomeViewModel 
    {

        /// <summary>
        /// 
        /// <value></value>
        /// </summary>
        public MonthlyProgress_ChargeableHours_Result EstimatedBillableHours
        { get; set; }

        /// <summary>
        /// 
        /// <value></value>        
        /// </summary>
        public EmployeeAllocatedProjects_Result Project
        { get; set; }


        /// <summary>
        /// 
        /// <value></value>        
        /// </summary>
        public IEnumerable<EmployeeAllocatedProjects_Result> Projects
        { get; set; }


    }
}