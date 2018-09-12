using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheets.Annotations
{

    [PSerializable]
    public class RecordActivity : OnMethodBoundaryAspect
    {

        /// <summary>
        /// 
        /// </summary>
        protected string _activityDescription = string.Empty;

        public RecordActivity(string activityDescription)
        {
            this._activityDescription = activityDescription;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }
    }
}
