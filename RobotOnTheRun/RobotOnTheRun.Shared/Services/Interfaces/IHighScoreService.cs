using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Services.Interfaces
{
    public interface IHighScoreService
    {
        int CreateHighScore(HighScoreViewModel newHighScore);
        List<HighScoreViewModel> GetAllScores();
        List<HighScoreViewModel> GetTopScores();
        int UpdateHighScore(HighScoreViewModel updateHighScore);
    }
}
