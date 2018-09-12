using Falcorp.Timesheets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falcorp.Timesheets.Models
{
    public partial class CaptureViewModel
    {
        public EmployeeTime capture { get; set; }

        public Employee employee { get; set; }

    }

    public partial class CaptureViewModel
    {
        [Required]
        public Guid EmployeeTimeID { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Client")]
        public string Client { get; set; }

        [DisplayName("Date To Capture")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CapturedDate { get; set; }

        [DisplayName("Chargeable Time")]
        public int ChargeableTime { get; set; }

        [DisplayName("Project Code")]
        public string ProjectCode { get; set; }

        [DisplayName("Project Owner")]
        public string ProjectOwner { get; set; }

        [DisplayName("Total Hours")]
        public int TotalBillableHours { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

    }


    public partial class CaptureViewModel
    {
         public MultiSelectList AllocatedProject { get; set; }
    }
}