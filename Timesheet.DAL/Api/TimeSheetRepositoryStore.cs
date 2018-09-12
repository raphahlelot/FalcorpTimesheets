
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Api
{
    using EF;
    using DAL.Repository;

    public class TimeSheetRepositoryStore : ITimeSheetRepositoryStore
    {
        protected TimeSheetsDataContext _timesheetDataStore;

        public TimeSheetRepositoryStore()
        {
                _timesheetDataStore = new TimeSheetsDataContext();

            #region --> Instantiates Repositories
                MonthlyProgressReportStore = new ChargeableBalanceRepository(_timesheetDataStore);
                ProjectRepositoryStore = new ProjectsRepository(_timesheetDataStore); 
            #endregion

        }

        public ChargeableBalanceRepository MonthlyProgressReportStore
        {get;set;}


        public ProjectsRepository ProjectRepositoryStore
        { get; set; }

        #region --> Gabbage Collection Stuff
        private bool _disposed = false;
        private static readonly object _syncLock = new object();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _timesheetDataStore.Dispose();
            }
        }
        #endregion

    }
}
