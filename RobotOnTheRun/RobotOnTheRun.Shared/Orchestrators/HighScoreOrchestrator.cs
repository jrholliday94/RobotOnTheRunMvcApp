using RobotOnTheRun.Domain;
using RobotOnTheRun.Domain.Entities;
using RobotOnTheRun.Shared.Orchestrators.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators
{
    public class HighScoreOrchestrator : IHighScoreOrchestrator
    {

        private readonly PersonContext _personContext;

        public HighScoreOrchestrator()
        {
            _personContext = new PersonContext();
        }

        public List<HighScoreViewModel> GetAllScores()
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

        public List<HighScoreViewModel> GetTopScores()
        {
            var topScores = _personContext.Scores.Select(x => new HighScoreViewModel
            {
                HighScoreId = x.HighScoreId,
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            topScores = topScores.OrderBy(x => x.Score).ToList();

            return topScores;
        }

        public async Task<int> CreateHighScore(HighScoreViewModel newHighScore)
        {
            _personContext.Scores.Add(new HighScore
            {
                HighScoreId = Guid.NewGuid(),
                PersonId = newHighScore.PersonId,
                Score = newHighScore.Score,
                DateAttained = newHighScore.DateAttained
             });

            return await _personContext.SaveChangesAsync();
        }

        // returns -1 for error, 0 for no update, and 1 for successfully updated
        public async Task<int> UpdateHighScore(HighScoreViewModel updateHighScore)
        {
            var searchScore = await _personContext.Scores.FindAsync(updateHighScore.PersonId);

            if (searchScore == null)
            {
                return -1;
            }

            if (searchScore.Score >= updateHighScore.Score)
            {
                return 0;
            }

            searchScore.HighScoreId = updateHighScore.HighScoreId;
            searchScore.Score = updateHighScore.Score;
            searchScore.DateAttained = updateHighScore.DateAttained;
            
            return 1;
        }
    }
}
