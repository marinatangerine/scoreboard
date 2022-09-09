namespace MSL.ScoreBoard.Data.Exceptions
{
    public class InvalidScoreException : Exception
    {
        public InvalidScoreException(int homeScore, int awayScore) : base($"Score not valid! {homeScore}-{awayScore}")
        {

        }
    }
}
