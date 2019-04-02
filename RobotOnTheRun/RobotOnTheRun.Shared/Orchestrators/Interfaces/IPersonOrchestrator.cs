using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    public interface IPersonOrchestrator
    {
        Task<int> CreatePerson(PersonViewModel person);
        Task<List<PersonViewModel>> GetAllPersons();
        Task<PersonViewModel> SearchPerson(Guid searchGuid);
        Task<bool> UpdatePerson(PersonViewModel person);

    }
}
