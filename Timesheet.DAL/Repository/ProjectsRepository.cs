
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Repository
{
    using System.Data.Entity;
    using Api;
    using EF;

    public class ProjectsRepository : Repository<EmployeeAllocatedProjects_Result>, IProjectsRepository
    {
        public ProjectsRepository(DbContext context) : base(context)
        {}


        public IEnumerable<EmployeeAllocatedProjects_Result> AllocatedProjects(string employeeId)
        {

            //
            foreach( var project in DataSource.EmployeeAllocatedProjects(employeeId))
            {
                yield return project;
            }
        }

        public EmployeeAllocatedProjects_Result HighestAllocatedProject(string employeeId)
        {

            //
            return DataSource.EmployeeAllocatedProjects(employeeId)
                             .Where( p => p.ProjectType.Equals("NEW_BUSINESS_PROJECT"))                    
                             .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeSheetsDataContext DataSource { get { return this._DbContext as TimeSheetsDataContext; } }
    }
}
