using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/persons")]

    public class PersonApiController : ApiController
    {
        private readonly PersonOrchestrator _personOrchestrator;

        public PersonApiController()
        {
            _personOrchestrator = new PersonOrchestrator();
        }

        [HttpGet]
        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _personOrchestrator.GetAllPersons();

            return persons;
        }
    }
}

