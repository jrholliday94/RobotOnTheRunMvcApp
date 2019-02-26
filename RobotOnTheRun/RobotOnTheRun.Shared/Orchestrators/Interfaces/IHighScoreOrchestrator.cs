using RobotOnTheRun.Shared.ViewModels;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Orchestrators.Interfaces
{
    interface IHighScoreOrchestrator
    {
        List<HighScoreViewModel> GetAllHighScores();
    }       
}
