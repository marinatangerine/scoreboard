using System.Collections.Concurrent;

namespace MSL.ScoreBoard.Data.Entities
{
    public class Scoreboard
    {
        private ConcurrentDictionary<int, Match> _matches { get; set; }

        public Scoreboard()
        {
            _matches = new ConcurrentDictionary<int, Match>();
        }
        public void Match_Start(string team1, string team2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> ScoreBoard_List()
        {
            throw new NotImplementedException();
        }

        public void Match_End(string team1, string team2)
        {
            throw new NotImplementedException();
        }

        public void Match_Update(string team1, string team2, int scoreTeam1, int scoreTeam2)
        {
            throw new NotImplementedException();
        }
    }
}
