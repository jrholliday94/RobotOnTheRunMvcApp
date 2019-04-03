using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/members")]
    public class ProjectMembersController : ApiController
    {
        private readonly IProjectMemberOrchestrator _projectMemberOrchestrator;

        public ProjectMembersController(IProjectMemberOrchestrator projectMemberOrchestrator)
        {
            _projectMemberOrchestrator = projectMemberOrchestrator;
        }

        [HttpGet]
        public List<ProjectMemberViewModel> GetAllMembers()
        {
            var members = _projectMemberOrchestrator.GetAllProjectMembers();

            return members;
        }


    }
}
