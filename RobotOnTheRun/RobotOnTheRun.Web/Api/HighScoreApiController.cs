using RobotOnTheRun.Shared.Orchestrators;
using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public List<HighScoreViewModel> GetAllScores()
        {
            var scores = _highScoreOrchestrator.GetAllScores();

            return scores;
        }

        public List<HighScoreViewModel> GetTopScores()
        {
            var highscores = _highScoreOrchestrator.GetTopScores();

            return highscores;
        }

        public async Task<int> CreateHighScore(Guid personID, int newHighScore)
        {
            var updatedChanges = await _highScoreOrchestrator.CreateHighScore(new HighScoreViewModel
            {
                PersonId = personID,
                Score = newHighScore,
                DateAttained = DateTime.Now
            });

            return updatedChanges;
        }

        public async Task<int> UpdateHighscore(Guid personID, int newHighScore)
        {
            // get list of current top scores
            List<HighScoreViewModel> currentHighScores = GetTopScores();

            // find high score player already has
            HighScoreViewModel currentPlayerScore = currentHighScores.Find(x => x.PersonId.Equals(personID));

            // update high score and save to db
            var saved = await _highScoreOrchestrator.UpdateHighScore(new HighScoreViewModel
            {
                PersonId = personID,
                Score = newHighScore,
                DateAttained = DateTime.Now
            });

            // Should always return 1.
            return saved;
        }
    }
}