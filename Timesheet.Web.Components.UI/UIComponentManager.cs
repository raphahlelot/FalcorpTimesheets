using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheets.Web.Components.UI
{

    using Api;
    using Toolbox;

    /// <summary>
    /// 
    /// </summary>
    public class UIComponentManager : IUIComponentManager
    {


        public UIComponentManager()
        {
                Form = new FormComponentsRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        public IFormComponentsRepository Form
        { get; set;}
    }
}
