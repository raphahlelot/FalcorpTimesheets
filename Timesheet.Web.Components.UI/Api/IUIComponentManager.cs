using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheets.Web.Components.UI.Api
{

    public interface IUIComponentManager
    {

        /// <summary>
        /// 
        /// </summary>
        IFormComponentsRepository Form
        { get; set; }
    }
}
