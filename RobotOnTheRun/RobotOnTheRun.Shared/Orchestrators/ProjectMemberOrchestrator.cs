using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class ProjectMemberOrchestrator : IProjectMemberOrchestrator
    {


        public List<ProjectMemberViewModel> GetAllProjectMembers()
        {
            var jared = new ProjectMemberViewModel
            {
                Name = "Jared Holliday",
                Email = "jrholliday@dmacc.edu",
                Role = "Repo Master"
            };

            var ben = new ProjectMemberViewModel
            {
                Name = "Ben Frederickson",
                Email = "bfrederickson@dmacc.edu",
                Role = "Work Flow Manager"
            };

            var ian = new ProjectMemberViewModel
            {
                Name = "Ian Tibe",
                Email = "imtibe@dmacc.edu",
                Role = "Unity Manager / Tester"
            };

            List<ProjectMemberViewModel> members = new List<ProjectMemberViewModel>()
            {
                jared,
                ben,
                ian
            };

            return members;

        }
    }
}
