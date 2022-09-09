namespace MSL.ScoreBoard.Data.Exceptions
{
    public class MatchNotFoundException : Exception
    {
        public MatchNotFoundException() : base($"Match not found!")
        {

        }
    }
}
