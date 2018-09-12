using System.Web.Mvc;

namespace Falcorp.Timesheets.Areas.ChargeableTime
{
    public class ChargeableTimeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChargeableTime";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChargeableTime_default",
                "ChargeableTime/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}