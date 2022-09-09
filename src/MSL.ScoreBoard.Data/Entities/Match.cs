namespace MSL.ScoreBoard.Data.Entities
{
    public class Match
    {
        public ContenderScore HomeContender { get; set; }
        public ContenderScore AwayContender { get; set; }

        public Match(string homeContenderName, string awayContenderName)
        {
            HomeContender = new ContenderScore(homeContenderName);
            AwayContender = new ContenderScore(awayContenderName);
        }
    }
}
