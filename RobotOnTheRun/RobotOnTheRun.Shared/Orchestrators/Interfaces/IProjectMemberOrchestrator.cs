using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    public interface IProjectMemberOrchestrator
    {
        List<ProjectMemberViewModel> GetAllProjectMembers();
    }
}
