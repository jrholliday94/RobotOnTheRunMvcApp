using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RobotOnTheRun.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            int statusCode;

            if(error is HttpException)
            {
                statusCode = (error as HttpException).GetHttpCode();
            }
            else
            {
                statusCode = 500;
            }

            if (statusCode == 404)
            {
                Response.Redirect("/Error/Missing");
            }
            else
            {
                Response.Redirect("/Error/Error");
            }
        }
    }
}
