using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Api
{
    using Falcorp.Timesheet.DAL.Repository;

    public interface ITimeSheetRepositoryStore
    {

        /// <summary>
        /// 
        /// </summary>
       ChargeableBalanceRepository MonthlyProgressReportStore { get; set; }


        /// <summary>
        /// 
        /// </summary>
       ProjectsRepository ProjectRepositoryStore { get; set; }


    }
}
