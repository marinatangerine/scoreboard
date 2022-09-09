namespace MSL.ScoreBoard.Data.Entities
{
    public class Match
    {
        public ContenderScore HomeContender { get; set; }
        public ContenderScore AwayContender { get; set; }
        public DateTime StartTime { get; set; }

        public Match(string homeContenderName, string awayContenderName)
        {
            HomeContender = new ContenderScore(homeContenderName);
            AwayContender = new ContenderScore(awayContenderName);
            StartTime = DateTime.Now;
        }

        public Match Score_Update(int? homeScore, int? awayScore)
        {
            HomeContender.Score_Update(homeScore);
            AwayContender.Score_Update(awayScore);
            return this;
        }
    }
}
