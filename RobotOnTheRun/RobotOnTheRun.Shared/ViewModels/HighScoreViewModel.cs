using System;

namespace RobotOnTheRun.Shared.ViewModels
{
    public class HighScoreViewModel
    {
        public Guid HighScoreId { get; set; }
        public Guid PersonId { get; set; }
        public int Score { get; set; }
        public DateTime DateAttained { get; set; }
    }
}
