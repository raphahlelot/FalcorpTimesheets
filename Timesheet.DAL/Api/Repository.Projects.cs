using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Api
{
    using EF;

    public interface IProjectsRepository : IRepository<EmployeeAllocatedProjects_Result>
    {

		/// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        EmployeeAllocatedProjects_Result HighestAllocatedProject(string employeeId);

		/// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        IEnumerable<EmployeeAllocatedProjects_Result> AllocatedProjects(string employeeId);

    }
}
