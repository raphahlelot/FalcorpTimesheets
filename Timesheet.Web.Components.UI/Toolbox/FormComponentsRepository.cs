using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Falcorp.Timesheets.Web.Components.UI.Toolbox
{
    using System.Web.Mvc;
    using Api;

    public class FormComponentsRepository : IFormComponentsRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectedValued"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public MultiSelectList MultiSelector<T>(string[] selectedValued, IEnumerable<T> children, string key, string label) where T : class
        {
            return new MultiSelectList(children, key, label, selectedValued);
        }
    }
}
