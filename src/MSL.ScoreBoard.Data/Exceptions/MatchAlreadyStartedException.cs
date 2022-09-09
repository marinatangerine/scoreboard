namespace MSL.ScoreBoard.Data.Exceptions
{
    public class MatchAlreadyStartedException : Exception
    {
        public MatchAlreadyStartedException(string homeContender, string awayContender) : base($"Match already started! {homeContender}-{awayContender}")
        {

        }
    }
}
