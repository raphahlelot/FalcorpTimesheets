using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falcorp.Timesheets.Api
{
    public class BaseController : Controller
    {

        public string EmployeeId {
            get
            {
                return User.Identity.GetEmployeeId();
            }
        }
    }
}