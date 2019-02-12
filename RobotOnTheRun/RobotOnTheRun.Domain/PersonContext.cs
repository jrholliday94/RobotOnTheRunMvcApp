using RobotOnTheRun.Domain.Entities;
using System.Data.Entity;

namespace RobotOnTheRun.Domain
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Users { get; set; }
        public DbSet<HighScore> Scores { get; set; }
    }
}
