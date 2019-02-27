using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using RobotOnTheRun.Domain;
using RobotOnTheRun.Domain.Entities;
using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.ViewModels;

namespace RobotOnTheRun.Web.Controllers
{
    [ExceptionHandler]
    public class ErrorController : Controller
    {
        private ErrorOrchestrator _errorOrchestrator = new ErrorOrchestrator();

        public ViewResult Error()
        {
            return View();
        }

        public ActionResult ForceError()
        {
            return View();
        }

        public ViewResult Missing()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("Missing");
        }

        public void CreateError()
        {
            _errorOrchestrator.ForceError();
        }

        public async Task<ActionResult> CreateErrorLog(ErrorViewModel error)
        {
            if (error.InnerExceptions == "" || error.InnerExceptions is null)
            {
                error.InnerExceptions = "None";
            }

            var createdErrorLog = await _errorOrchestrator.CreateErrorLog(new ErrorViewModel
            {
                ErrorId = Guid.NewGuid(),
                ErrorDate = DateTime.Now,
                ErrorMessage = error.ErrorMessage,
                StackTrace = error.StackTrace,
                InnerExceptions = error.InnerExceptions
            });

            return Json(createdErrorLog, JsonRequestBehavior.AllowGet);
        }
    }

    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string innerEx = "";

            if (filterContext.Exception.InnerException is null)
            {
                innerEx = "None";
            }
            else
            {
                innerEx = filterContext.Exception.InnerException.ToString();
            }

            if (!filterContext.ExceptionHandled)
            {
                Error logger = new Error();

                logger = new Error()
                {
                    ErrorMessage = filterContext.Exception.Message,
                    StackTrace = filterContext.Exception.StackTrace,
                    ErrorDate = DateTime.Now,
                    ErrorId = Guid.NewGuid(),
                    InnerExceptions = innerEx
                };

                PersonContext pc = new PersonContext();
                pc.Errors.Add(logger);
                pc.SaveChanges();

                filterContext.ExceptionHandled = true;

                filterContext.Result = new ViewResult { ViewName = "Error" };
            }
        }
    }
}