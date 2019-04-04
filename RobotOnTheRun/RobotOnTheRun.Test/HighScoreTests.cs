using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotOnTheRun.Shared.Services;
using RobotOnTheRun.Shared.ViewModels;
using System;
using System.Collections.Generic;

namespace RobotOnTheRun.Test
{
    [TestClass]
    public class HighScoreTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestMethod]
        public void CreateHighScores_VerifyInOrder_ReturnsTrueWhenCreationSuccessful()
        {
            //setup

            // Create HighScoreViewModels
            var scoreOne = CreateHighScore(Guid.Parse("3448713a-965f-4d2d-aece-f73f8c0bcdae"), 500);
            var scoreTwo = CreateHighScore(Guid.Parse("49bba749-e560-4416-b22b-4258d8f9a37e"), 400);
            var scoreThree = CreateHighScore(Guid.Parse("3c95b58b-1221-41dc-9fa7-40b4f445acd9"), 300);
            
            // High score service used since orchestrator mock wasnt working.
            // HighScoreService 
            var highScoreService = _mocker.Create<HighScoreService>();

            //Assert
            // Mocking creation of high score method, method returns SaveChangesAsync(); which returns an int of objects saved.
            // Mocking one object each, so result is int = 1 returned
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, highScoreService.CreateHighScore(scoreOne));
            Assert.AreEqual(expectedResult, highScoreService.CreateHighScore(scoreTwo));
            Assert.AreEqual(expectedResult, highScoreService.CreateHighScore(scoreThree));
        }

        [TestMethod]
        public void SetNewHighScore_ReturnsTrue()
        {
            //setup
            var newScore = CreateHighScore(Guid.Parse("8e13512a-9a55-4a8c-906d-2b80edd27d7b"), 500);
            var highScoreService = _mocker.Create<HighScoreService>();


            //Assert
            var expectedResult = 1;
            Assert.AreEqual(expectedResult, highScoreService.CreateHighScore(newScore));
        }

        [TestMethod]
        public void TryToSetNewHighScore_ReturnsFalse()
        {
            //setup
            var newScore = CreateHighScore(Guid.Parse("8e13512a-9a55-4a8c-906d-2b80edd27d7b"), 500);
            var highScoreService = _mocker.Create<HighScoreService>();

            //Assert
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, highScoreService.CreateHighScore(newScore));
        }



        [TestMethod]
        public void CreateHighScore_UpdateHighScore_RetrieveLeaderBoard_ValidateNewScoreOnLb_ValidateOtherScoresOnLb_ReturnsTrue()
        {

            // setup
            var highScoreService = _mocker.Create<HighScoreService>();
            HighScoreViewModel newScore = new HighScoreViewModel
            {
                HighScoreId = Guid.Parse("9bf3b5c2-9eaa-425b-b0be-e884cfc3d6f0"),
                PersonId = Guid.Parse("84b4ecb4-569f-4b4e-b234-7c79fcd0a360"),
                Score = 600,
                DateAttained = DateTime.Today
            };

            // Get leaderboard
            List<HighScoreViewModel> leaderboard = highScoreService.GetTopScores();

            // Search for new score
            var foundScore = leaderboard.Find(x => x.PersonId == newScore.PersonId);

            // Assert
            // Verify creation is successful
            Assert.AreEqual(1,highScoreService.UpdateHighScore(newScore));

            // Verify new score is the same as created score
            Assert.AreEqual(foundScore.PersonId, newScore.PersonId);
        }

        // Used to set up high scores
        private HighScoreViewModel CreateHighScore(Guid newPersonId, int newScore)
        {
            return new HighScoreViewModel
            {
                PersonId = newPersonId,
                Score = newScore,
                DateAttained = DateTime.Now
            };
        }
    }
}
