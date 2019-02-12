namespace RobotOnTheRun.Domain.Migrations
{
    using RobotOnTheRun.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonContext context)
        {
            context.Users.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                FirstName = "Jared",
                LastName = "Holliday",
                DateCreated = DateTime.Today,
                Email = "jrholliday@dmacc.edu"
            }
            );

            context.Users.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("dc31053b-c68e-4e75-9b4d-805b6890ee26"),
                FirstName = "Ben",
                LastName = "Frederickson",
                DateCreated = DateTime.Today,
                Email = "bfrederickson@dmacc.edu"
            });

            context.Users.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("0354e35a-3a17-4008-8572-52cdfed9219b"),
                FirstName = "Ian",
                LastName = "Tibe",
                DateCreated = DateTime.Today,
                Email = "imtibe@dmacc.edu"
            });


            context.Scores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("9bf3b5c2-9eaa-425b-b0be-e884cfc3d6f0"),
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                Score = 500,
                DateAttained = DateTime.Today
            });

            context.Scores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("8a51e016-bbd6-4799-a7bc-5e57aea8b5a0"),
                PersonId = Guid.Parse("dc31053b-c68e-4e75-9b4d-805b6890ee26"),
                Score = 400,
                DateAttained = DateTime.Today
             });


            context.Scores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("35320618-cb3d-4a54-ac86-fd81eff71371"),
                PersonId = Guid.Parse("0354e35a-3a17-4008-8572-52cdfed9219b"),
                Score = 300,
                DateAttained = DateTime.Today
            });


            context.Scores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("a6ac6f37-00b2-459a-bcb9-9f6b1650e7a0"),
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                Score = 200,
                DateAttained = DateTime.Today
            });

            context.Scores.AddOrUpdate(new HighScore
            {
                HighScoreId = Guid.Parse("d75fb285-c031-4416-befd-65c8d900a7de"),
                PersonId = Guid.Parse("dc31053b-c68e-4e75-9b4d-805b6890ee26"),
                Score = 100,
                DateAttained = DateTime.Today
            });

        }
    }
}
