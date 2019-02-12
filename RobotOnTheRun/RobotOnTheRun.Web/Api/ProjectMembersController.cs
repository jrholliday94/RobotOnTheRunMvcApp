using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/members")]
    public class ProjectMembersController : ApiController
    {
        private readonly ProjectMemberOrchestrator _projectMemberOrchestrator;

        public ProjectMembersController()
        {
            _projectMemberOrchestrator = new ProjectMemberOrchestrator();
        }

        [HttpGet]
        public List<ProjectMemberViewModel> GetAllMembers()
        {
            var members = _projectMemberOrchestrator.GetAllProjectMembers();

            return members;
        }


    }
}
