using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RobotOnTheRun.Web.Api
{
    [Route("api/v1/scores")]
    public class HighScoreApiController : ApiController
    {
        private readonly IHighScoreOrchestrator _highScoreOrchestrator;

        public HighScoreApiController(IHighScoreOrchestrator highScoreOrchestrator)
        {
            _highScoreOrchestrator = highScoreOrchestrator;
        }

        [HttpGet]
        public List<HighScoreViewModel> GetHighScores()
        {
            var scores = _highScoreOrchestrator.GetAllHighScores();

            return scores;
        }
    }
}