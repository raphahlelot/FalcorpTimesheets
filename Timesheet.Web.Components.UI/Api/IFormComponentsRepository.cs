using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Falcorp.Timesheets.Web.Components.UI.Api
{
    public interface IFormComponentsRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectedValued"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        MultiSelectList MultiSelector<T>(string[] selectedValued, IEnumerable<T> children, string key, string label) where T : class;

    }
}
