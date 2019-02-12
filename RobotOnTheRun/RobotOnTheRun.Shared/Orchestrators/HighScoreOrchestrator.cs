using RobotOnTheRun.Domain;
using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class HighScoreOrchestrator
    {
        private readonly PersonContext _personContext;

        public HighScoreOrchestrator()
        {
            _personContext = new PersonContext();
        }

        public List<HighScoreViewModel> GetAllHighScores()
        {
            var scores = _personContext.Scores.Select(x => new HighScoreViewModel
            {
                HighScoreId = x.HighScoreId,
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            return scores;
        }
    }
}
