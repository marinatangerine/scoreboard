using MSL.ScoreBoard.Data.Entities;

namespace MSL.ScoreBoard.Data.Extensions
{
    public static class HashExtensions
    {
        public static int GetHash(this Match match)
        {
            return $"{match.HomeContender.Name}-{match.AwayContender.Name}".GetHashCode();
        }
    }
}
