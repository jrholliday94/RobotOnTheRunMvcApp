using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using RobotOnTheRun.Shared.ViewModels;

namespace RobotOnTheRun.Web.Controllers
{
    [ExceptionHandler]
    public class PersonController : Controller
    {
        private PersonOrchestrator _personOrchestrator = new PersonOrchestrator();

        // GET: Person
        public async Task<ActionResult> Index()
        {
            var personDisplayModel = new PersonDisplayModel
            {
                Persons = await _personOrchestrator.GetAllPersons()
            };

            return View(personDisplayModel);
        }

        public async Task<ActionResult> Create(CreatePersonModel person)
        {
            string userId = Session["userId"].ToString();

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                return View();
            }

            if(person.DateCreated is null)
            {
                person.DateCreated = System.DateTime.Now;
            }

            var updatedCount = await _personOrchestrator.CreatePerson(new PersonViewModel
            {
                PersonId = Guid.Parse(userId),
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateCreated = person.DateCreated,
                Email = person.Email,
                Gender = person.Gender,
                PhoneNumber = person.PhoneNumber
            });

            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public async Task<JsonResult> UpdatePerson(UpdatePersonModel person)
        {
            if (person.PersonId == Guid.Empty)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = await _personOrchestrator.UpdatePerson(new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateCreated = person.DateCreated,
                Email = person.Email,
                Gender = person.Gender,
                PhoneNumber = person.PhoneNumber
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Search(string searchGuid)
        {
            Guid parsedGuid = Guid.Parse(searchGuid);

            var viewModel = await _personOrchestrator.SearchPerson(parsedGuid);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
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