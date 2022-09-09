namespace MSL.ScoreBoard.Data.Exceptions
{
    public class InvalidContenderException : Exception
    {
        public InvalidContenderException(string contenderName) : base($"Contender not valid! {contenderName}")
        {

        }
    }
}
