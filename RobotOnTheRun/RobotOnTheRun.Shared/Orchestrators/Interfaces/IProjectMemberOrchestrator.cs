using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    interface IProjectMemberOrchestrator
    {
        List<ProjectMemberViewModel> GetAllProjectMembers();
    }
}
