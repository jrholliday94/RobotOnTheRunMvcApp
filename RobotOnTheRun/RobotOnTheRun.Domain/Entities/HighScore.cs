using System;
using System.ComponentModel.DataAnnotations;

namespace RobotOnTheRun.Domain.Entities
{
    public class HighScore
    {
        [Key]
        public Guid HighScoreId { get; set; }
        public Guid PersonId { get; set; }
        public int Score { get; set; }
        public DateTime DateAttained { get; set; }
    }
}
