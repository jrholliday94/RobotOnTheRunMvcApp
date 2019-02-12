using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/scores")]
    public class HighScoreApiController : ApiController
    {
        private readonly HighScoreOrchestrator _highScoreOrchestrator;

        public HighScoreApiController()
        {
            _highScoreOrchestrator = new HighScoreOrchestrator();
        }

        [HttpGet]

        public List<HighScoreViewModel> GetAllScores()
        {
            var scores = _highScoreOrchestrator.GetAllHighScores();

            return scores;
        }
    }
}