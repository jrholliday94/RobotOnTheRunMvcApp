using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/persons")]
    public class PersonApiController : ApiController
    {

        private readonly IPersonOrchestrator _personOrchestrator;

        public PersonApiController(IPersonOrchestrator personOrchestrator )
        {
            _personOrchestrator = personOrchestrator;
        }

        [HttpGet]
        public Task<List<PersonViewModel>> GetAllPersons()
        {
            var persons = _personOrchestrator.GetAllPersons();

            return persons;
        }
    }
}

