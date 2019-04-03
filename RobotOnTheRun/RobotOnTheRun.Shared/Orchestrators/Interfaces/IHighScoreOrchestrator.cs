using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    public interface IHighScoreOrchestrator
    {
        List<HighScoreViewModel> GetAllScores();
        List<HighScoreViewModel> GetTopScores();
        Task<int> CreateHighScore(HighScoreViewModel newHighScore);
        Task<int> UpdateHighScore(HighScoreViewModel updateHighScore);

    }       
}
