using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Web.Mvc;

namespace RobotOnTheRun.Web.Controllers
{
    [ExceptionHandler]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected async void OnExceptionAsync(ExceptionContext exception)
        {
            exception.ExceptionHandled = true;

            ErrorOrchestrator errorOrch = new ErrorOrchestrator();

            ErrorViewModel errorViewModel = new ErrorViewModel
            {
                ErrorId = Guid.NewGuid(),
                ErrorDate = DateTime.Now,
                StackTrace = exception.Exception.StackTrace,
                ErrorMessage = exception.Exception.Message
            };

            if (exception.Exception.InnerException is null)
            {
                errorViewModel.InnerExceptions = "None";
            }
            else
            {
                errorViewModel.InnerExceptions = exception.Exception.InnerException.ToString();
            }

            await errorOrch.CreateErrorLog(errorViewModel);

            exception.Result = RedirectToAction("Error", "Error");

        }
    }
}