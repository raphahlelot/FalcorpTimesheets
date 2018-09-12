
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Falcorp.Timesheet.DAL.Api
{
    using EF;
    using Timesheets.Annotations;

    public interface IChargeableBalanceRepository : IRepository<ChargeableHoursBalance>
    {
        /// <summary>
        /// 
        /// </summary>
        string ChargeableMonth
        { get; }

        /// <summary>
        /// 
        /// </summary>
        string ChargeableYear
        { get; }

        /// <summary>
        /// 
        /// </summary>
        double TotalBillableHours
        { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        MonthlyProgress_ChargeableHours_Result MonthlyProgress(string employeeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<MonthlyProgress_ChargeableHours_Result> MonthlyProgressAsync(string employeeId);

    }
}
