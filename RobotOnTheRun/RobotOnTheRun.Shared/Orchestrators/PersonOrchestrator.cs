using RobotOnTheRun.Domain;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class PersonOrchestrator
    {
        private readonly PersonContext _personContext;

        public PersonOrchestrator()
        {
            _personContext = new PersonContext();
        }

        public async Task<int> CreatePerson(PersonViewModel person)
        {
            var tester = await _personContext.Users.Where(x => x.PersonId.Equals(person.PersonId))
               .FirstOrDefaultAsync();

            if (tester != null)
            {
                return -5;
            }

            _personContext.Users.Add(new Domain.Entities.Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateCreated = person.DateCreated,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return await _personContext.SaveChangesAsync();
        }

        public async Task<List<PersonViewModel>> GetAllPersons()
        {
            var persons = await _personContext.Users.Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                DateCreated = x.DateCreated,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();

            return persons;
        }

        public async Task<PersonViewModel> SearchPerson(Guid searchGuid)
        {
            var person = await _personContext.Users.Where(x => x.PersonId.Equals(searchGuid))
                .FirstOrDefaultAsync();

            if(person == null)
            {
                return new PersonViewModel();
            }

            var viewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateCreated = person.DateCreated,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            };

            return viewModel;
        }

        public async Task<bool> UpdatePerson(PersonViewModel person)
        {
            var updatePerson = await _personContext.Users.FindAsync(person.PersonId);

            if(updatePerson == null)
            {
                return false;
            }

            updatePerson.FirstName = person.FirstName;
            updatePerson.LastName = person.LastName;
            updatePerson.Gender = person.Gender;
            updatePerson.PhoneNumber = person.PhoneNumber;
            updatePerson.Email = person.Email;

            await _personContext.SaveChangesAsync();

            return true;
        }

    }
}
