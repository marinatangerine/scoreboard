using MSL.ScoreBoard.ConsoleApp;
using MSL.ScoreBoard.Data.Entities;

var _scoreBoard = new Scoreboard();

//this simulates incoming data behavior
//it could be windows service incoming call, rest api request, queue consumer, etc
Match_Start(_scoreBoard, Constants.TEAM1, Constants.TEAM2);
Match_Start(_scoreBoard, Constants.TEAM3, Constants.TEAM4);
Match_Update(_scoreBoard, Constants.TEAM1, 0, Constants.TEAM2, 1);
Match_Start(_scoreBoard, Constants.TEAM5, Constants.TEAM6);
Match_Update(_scoreBoard, Constants.TEAM1, 0, Constants.TEAM2, 2);
Match_Update(_scoreBoard, Constants.TEAM3, 1, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM3, 2, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM1, 0, Constants.TEAM2, 3);
Match_Start(_scoreBoard, Constants.TEAM7, Constants.TEAM8);
Match_Update(_scoreBoard, Constants.TEAM7, 1, Constants.TEAM8, 0);
Match_Update(_scoreBoard, Constants.TEAM7, 1, Constants.TEAM8, 1);
Match_Update(_scoreBoard, Constants.TEAM3, 3, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM3, 4, Constants.TEAM4, 0);
Match_Start(_scoreBoard, Constants.TEAM9, Constants.TEAM10);
Match_Update(_scoreBoard, Constants.TEAM7, 2, Constants.TEAM8, 1);
Match_Update(_scoreBoard, Constants.TEAM7, 3, Constants.TEAM8, 1);
Match_Update(_scoreBoard, Constants.TEAM5, 0, Constants.TEAM6, 1);
Match_Update(_scoreBoard, Constants.TEAM5, 1, Constants.TEAM6, 1);
Match_Update(_scoreBoard, Constants.TEAM9, 1, Constants.TEAM10, 0);
Match_Update(_scoreBoard, Constants.TEAM3, 5, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM7, 4, Constants.TEAM8, 1);
Match_Update(_scoreBoard, Constants.TEAM7, 4, Constants.TEAM8, 2);
Match_Update(_scoreBoard, Constants.TEAM3, 6, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM9, 2, Constants.TEAM10, 0);
Match_Update(_scoreBoard, Constants.TEAM3, 7, Constants.TEAM4, 0);
Match_Update(_scoreBoard, Constants.TEAM1, 0, Constants.TEAM2, 4);
Match_Update(_scoreBoard, Constants.TEAM9, 2, Constants.TEAM10, 1);
Match_Update(_scoreBoard, Constants.TEAM7, 5, Constants.TEAM8, 2);
Match_Update(_scoreBoard, Constants.TEAM7, 6, Constants.TEAM8, 2);
Match_Update(_scoreBoard, Constants.TEAM1, 0, Constants.TEAM2, 5);
Match_Update(_scoreBoard, Constants.TEAM5, 2, Constants.TEAM6, 1);
Match_Update(_scoreBoard, Constants.TEAM7, 6, Constants.TEAM8, 3);
Match_Start(_scoreBoard, Constants.TEAM11, Constants.TEAM12);
Match_Update(_scoreBoard, Constants.TEAM7, 6, Constants.TEAM8, 4);
Match_Update(_scoreBoard, Constants.TEAM3, 8, Constants.TEAM4, 1);
Match_Update(_scoreBoard, Constants.TEAM5, 2, Constants.TEAM6, 2);
Match_Update(_scoreBoard, Constants.TEAM3, 9, Constants.TEAM4, 2);
Match_Update(_scoreBoard, Constants.TEAM7, 6, Constants.TEAM8, 5);
Match_Update(_scoreBoard, Constants.TEAM3, 10, Constants.TEAM4, 2);
Match_Update(_scoreBoard, Constants.TEAM7, 6, Constants.TEAM8, 6);
Match_Update(_scoreBoard, Constants.TEAM9, 3, Constants.TEAM10, 1);
Match_End(_scoreBoard, Constants.TEAM11, Constants.TEAM12);

static void Match_Start(Scoreboard scoreBoard, string homeTeam, string awayTeam)
{
    Console.WriteLine($"{Constants.MATCH_STARTED} {homeTeam} - {awayTeam}");
    scoreBoard.Match_Start(homeTeam, awayTeam);
    ScoreBoard_Print(scoreBoard);
}

static void Match_Update(Scoreboard scoreBoard, string homeTeam, int homeScore, string awayTeam, int awayScore)
{
    Console.WriteLine($"{Constants.MATCH_UPDATED} {homeTeam} {homeScore} - {awayTeam} {awayScore}");
    scoreBoard.Match_Update(homeTeam, awayTeam, homeScore, awayScore);
    ScoreBoard_Print(scoreBoard);
}

static void Match_End(Scoreboard scoreBoard, string homeTeam, string awayTeam)
{
    Console.WriteLine($"{Constants.MATCH_FINISHED} {homeTeam} - {awayTeam}");
    scoreBoard.Match_End(homeTeam, awayTeam);
    ScoreBoard_Print(scoreBoard);
}

static void ScoreBoard_Print(Scoreboard scoreBoard)
{
    var scores = scoreBoard.ScoreBoard_List();
    foreach (var item in scores)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine(string.Empty);
}