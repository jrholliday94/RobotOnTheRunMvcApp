using RobotOnTheRun.Domain;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class PersonOrchestrator
    {
        private readonly PersonContext _personContext;

        public PersonOrchestrator()
        {
            _personContext = new PersonContext();
        }

        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _personContext.Users.Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateCreated = x.DateCreated,
                Email = x.Email
            }).ToList();

            return persons;
        }
    }
}
