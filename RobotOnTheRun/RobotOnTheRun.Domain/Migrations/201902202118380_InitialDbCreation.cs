namespace RobotOnTheRun.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HighScores",
                c => new
                    {
                        HighScoreId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        Score = c.Int(nullable: false),
                        DateAttained = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HighScoreId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.HighScores");
        }
    }
}
