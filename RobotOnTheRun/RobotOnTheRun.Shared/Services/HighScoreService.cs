using RobotOnTheRun.Domain.Entities;
using RobotOnTheRun.Shared.Services.Interfaces;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;

namespace RobotOnTheRun.Shared.Services
{
    public class HighScoreService : IHighScoreService
    {
        public int CreateHighScore(HighScoreViewModel newHighScore)
        {
            // Mocking creation of high score method, method returns SaveChangesAsync(); which returns an int of objects saved.
            // Mocking one object each, so result is int = 1 returned
            return 1;
        }

        // Creates list of fake score to return
        public List<HighScoreViewModel> GetAllScores()
        {
            HighScoreViewModel scoreOne = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("9bf3b5c2-9eaa-425b-b0be-e884cfc3d6f0"),
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                Score = 500,
                DateAttained = DateTime.Today
            };

            HighScoreViewModel scoreTwo = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("8a51e016-bbd6-4799-a7bc-5e57aea8b5a0"),
                PersonId = Guid.Parse("dc31053b-c68e-4e75-9b4d-805b6890ee26"),
                Score = 400,
                DateAttained = DateTime.Today
            };

            HighScoreViewModel scoreThree = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("35320618-cb3d-4a54-ac86-fd81eff71371"),
                PersonId = Guid.Parse("0354e35a-3a17-4008-8572-52cdfed9219b"),
                Score = 300,
                DateAttained = DateTime.Today
            };

            List<HighScoreViewModel> scoreList = new List<HighScoreViewModel>
            {
                scoreOne,
                scoreTwo,
                scoreThree
            };

            return scoreList;
        }

        // Creates list of fake scores to return
        public List<HighScoreViewModel> GetTopScores()
        {
            HighScoreViewModel scoreOne = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("9bf3b5c2-9eaa-425b-b0be-e884cfc3d6f0"),
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                Score = 500,
                DateAttained = DateTime.Today
            };

            HighScoreViewModel scoreTwo = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("8a51e016-bbd6-4799-a7bc-5e57aea8b5a0"),
                PersonId = Guid.Parse("dc31053b-c68e-4e75-9b4d-805b6890ee26"),
                Score = 400,
                DateAttained = DateTime.Today
            };

            HighScoreViewModel scoreThree = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("35320618-cb3d-4a54-ac86-fd81eff71371"),
                PersonId = Guid.Parse("0354e35a-3a17-4008-8572-52cdfed9219b"),
                Score = 300,
                DateAttained = DateTime.Today
            };

            List<HighScoreViewModel> scoreList = new List<HighScoreViewModel>
            {
                scoreOne,
                scoreTwo,
                scoreThree
            };

            return scoreList;
        }

        // Original method returns -1 for error, 0 for no update, and 1 for successfully updated
        // Assuming success so returning 1
        public int UpdateHighScore(HighScoreViewModel updateHighScore)
        {
            return 1;
        }
    }
}
