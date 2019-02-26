using System.Web.Mvc;
using RobotOnTheRun.Web.Controllers;

namespace RobotOnTheRun.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
