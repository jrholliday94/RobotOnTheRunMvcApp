using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotOnTheRun.Shared.ViewModels;
using System;

namespace RobotOnTheRun.Test
{
    [TestClass]
    public class HighScoreTests
    {

        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestMethod]
        public void UpdateHighScore_ReturnsTrueWhenUpdateSuccessful()
        {
            // setup
            //_mocker.GetMock<GetAllScores>()




            //act




            //assert
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
