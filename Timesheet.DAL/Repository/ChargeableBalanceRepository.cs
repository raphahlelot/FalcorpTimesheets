using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Repository
{

    using Api;
    using EF;

    public class ChargeableBalanceRepository : Repository<ChargeableHoursBalance>, IChargeableBalanceRepository
    {

        public ChargeableBalanceRepository(DbContext context) : base(context)
        {}

        /// <summary>
        /// 
        /// </summary>
        public string ChargeableMonth
        {
            get
            {
                return DataSource.ChargeableHoursBalances
                                 .Where(c => c.IsCurrentMonth == true)
                                 .Select(c => c.Month)
                                 .SingleOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double TotalBillableHours
        {
            get
            {
                var billableHours =  DataSource.ChargeableHoursBalances
                                    .Where(c => c.IsCurrentMonth == true)
                                    .Select(c => c.BillableHours)
                                    .SingleOrDefault();
                return (double)billableHours;
            }
        }


        public TimeSheetsDataContext DataSource { get { return this._DbContext as TimeSheetsDataContext; } }

        public string ChargeableYear
        {
            get
            {
                return DataSource.ChargeableHoursBalances
                                 .Where(c => c.IsCurrentMonth == true)
                                 .Select(c => c.Year)
                                 .SingleOrDefault();
            }
        }


        public MonthlyProgress_ChargeableHours_Result MonthlyProgress(string employeeId)
        {
                return DataSource.MonthlyProgress_ChargeableHours(employeeId).SingleOrDefault();
        }


        public async Task<MonthlyProgress_ChargeableHours_Result> MonthlyProgressAsync(string employeeId)
        {
            var executionResults = DataSource.MonthlyProgress_ChargeableHours(employeeId).SingleOrDefault();

            return await Task.FromResult(executionResults);
        }
    }
}
