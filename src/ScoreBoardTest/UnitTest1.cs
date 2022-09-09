using MSL.ScoreBoard.Data.Entities;
using MSL.ScoreBoard.Data.Exceptions;

namespace ScoreBoardTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Match_Start()
        {
            var scoreboard = new Scoreboard();
            //Arrange
            var team1 = "Mexico";
            var team2 = "Canada";

            //Act
            scoreboard.Match_Start(team1, team2);

            //Asset
            var matches = scoreboard.ScoreBoard_List();
            var added = matches.Any(q => q.HomeContender.Name.Equals(team1) && q.AwayContender.Name.Equals(team2));
        }

        [TestMethod]
        public void Match_IncompleteStart()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "";

            //Act & Asset
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_Start(team1, team2));
        }

        [TestMethod]
        public void Match_CreateExisting()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";

            //Act
            scoreboard.Match_Start(team1, team2);

            //Asset
            Assert.ThrowsException<MatchAlreadyStartedException>(() => scoreboard.Match_Start(team1, team2));
        }

        [TestMethod]
        public void Match_CreateExistingContender()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var team3 = "Spain";

            //Act
            scoreboard.Match_Start(team1, team2);

            //Asset
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_Start(team1, team3));
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_Start(team3, team1));
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_Start(team2, team3));
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_Start(team3, team2));
        }


        [TestMethod]
        public void Match_End()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var team3 = "Spain";
            var team4 = "Brazil";

            //Act
            scoreboard.Match_Start(team1, team2);
            scoreboard.Match_Start(team3, team4);
            scoreboard.Match_End(team1, team2);

            //Asset
            var matches = scoreboard.ScoreBoard_List();
            var addedMatch2 = matches.Any(q => q.HomeContender.Name.Equals(team3) && q.AwayContender.Name.Equals(team4));
            Assert.IsTrue(addedMatch2);
            var deleteMatch1 = matches.Any(q => q.HomeContender.Name.Equals(team1) && q.AwayContender.Name.Equals(team2));
            Assert.IsFalse(deleteMatch1);
        }

        [TestMethod]
        public void Match_IncompleteEnd()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";

            //Act
            scoreboard.Match_Start(team1, team2);

            //Asset
            Assert.ThrowsException<InvalidContenderException>(() => scoreboard.Match_End(team1, string.Empty));
        }

        [TestMethod]
        public void Match_Update()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var scoreTeam1 = 0;
            var scoreTeam2 = 1;

            //Act
            scoreboard.Match_Start(team1, team2);
            scoreboard.Match_Update(team1, team2, scoreTeam1, scoreTeam2);

            //Asset
            var matches = scoreboard.ScoreBoard_List();
            var result = matches.Any(q => q.HomeContender.Name.Equals(team1) && q.AwayContender.Name.Equals(team2) && q.HomeContender.Score.Equals(0) && q.AwayContender.Score.Equals(1));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Match_UpdateNonExisting()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var scoreTeam1 = 0;
            var scoreTeam2 = 1;
            var team3 = "Spain";
            var team4 = "Brazil";

            //Act
            scoreboard.Match_Start(team1, team2);
            scoreboard.Match_Update(team1, team2, scoreTeam1, scoreTeam2);

            //Asset
            Assert.ThrowsException<MatchNotFoundException>(() => scoreboard.Match_Update(team3, team4, scoreTeam1, scoreTeam2));
        }

        [TestMethod]
        public void Invalid_Score()
        {
            var scoreboard = new Scoreboard();
            //Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var scoreTeam1 = 0;
            var scoreTeam2 = -1;

            //Act
            scoreboard.Match_Start(team1, team2);

            //Asset
            Assert.ThrowsException<InvalidScoreException>(() => scoreboard.Match_Update(team1, team1, scoreTeam1, scoreTeam2));
        }

        [TestMethod]
        public void Scoreboard_Sort()
        {
            var scoreboard = new Scoreboard();
            // Arrange
            var team1 = "Mexico";
            var team2 = "Canada";
            var team3 = "Spain";
            var team4 = "Brazil";
            var team5 = "Germany";
            var team6 = "France";
            var team7 = "Uruguay";
            var team8 = "Italy";
            var team9 = "Argentina";
            var team10 = "Australia";

            //Act
            scoreboard.Match_Start(team1, team2);
            scoreboard.Match_Start(team3, team4);
            scoreboard.Match_Start(team5, team6);
            scoreboard.Match_Start(team7, team8);
            scoreboard.Match_Start(team9, team10);
            scoreboard.Match_Update(team1, team2, 0, 1);
            scoreboard.Match_Update(team1, team2, 0, 5);
            scoreboard.Match_Update(team3, team4, 10, 2);
            scoreboard.Match_Update(team7, team8, 6, 6);
            scoreboard.Match_Update(team5, team6, 2, 2);
            scoreboard.Match_Update(team9, team10, 3, 1);

            var results = scoreboard.ScoreBoard_List().ToList();

            //Asset
            Assert.IsTrue(results[0].HomeContender.Name.Equals(team7) && results[0].AwayContender.Name.Equals(team8));
            Assert.IsTrue(results[1].HomeContender.Name.Equals(team3) && results[1].AwayContender.Name.Equals(team4));
            Assert.IsTrue(results[2].HomeContender.Name.Equals(team1) && results[2].AwayContender.Name.Equals(team2));
            Assert.IsTrue(results[3].HomeContender.Name.Equals(team9) && results[3].AwayContender.Name.Equals(team10));
            Assert.IsTrue(results[4].HomeContender.Name.Equals(team5) && results[4].AwayContender.Name.Equals(team6));
        }
    }
}