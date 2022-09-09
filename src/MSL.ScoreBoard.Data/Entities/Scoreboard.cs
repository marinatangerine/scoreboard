using MSL.ScoreBoard.Data.Extensions;
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
        public void Match_Start(string homeContender, string awayContender)
        {
            var match = new Match(homeContender, awayContender);

            //check valid name for contender 1
            if (string.IsNullOrWhiteSpace(match.HomeContender.Name))
            {
                throw new ArgumentNullException(match.HomeContender.Name);
            }

            //check valid name for contender 2
            if (string.IsNullOrWhiteSpace(match.AwayContender.Name))
            {
                throw new ArgumentNullException(match.AwayContender.Name);
            }

            //check match doesn't exist
            var matchKey = match.GetHash();
            if (_matches.ContainsKey(matchKey))
            {
                throw new Exception("Match already exists");
            }

            _matches.AddOrUpdate(match.GetHash(), match, (k, v) => match);
        }

        public IEnumerable<Match> ScoreBoard_List()
                    => _matches.Values.OrderByDescending(q => q.HomeContender.Score + q.AwayContender.Score).ThenByDescending(q => q.StartTime);

        public void Match_End(string homeContender, string awayContender)
        {
            var match = new Match(homeContender, awayContender);

            //check valid name for contender 1
            if (string.IsNullOrWhiteSpace(match.HomeContender.Name))
            {
                throw new ArgumentNullException(match.HomeContender.Name);
            }

            //check valid name for contender 2
            if (string.IsNullOrWhiteSpace(match.AwayContender.Name))
            {
                throw new ArgumentNullException(match.AwayContender.Name);
            }

            //check match exists
            var matchKey = match.GetHash();
            if (!_matches.ContainsKey(matchKey))
            {
                throw new Exception("Match already exists");
            }

            _matches.TryRemove(match.GetHash(), out var ignored);
        }

        public void Match_Update(string homeContender, string awayContender, int homeScore, int awayScore)
        {
            var match = new Match(homeContender, awayContender);
            match.Score_Update(homeScore, awayScore);

            //check valid name for contender 1
            if (string.IsNullOrWhiteSpace(match.HomeContender.Name))
            {
                throw new ArgumentNullException(match.HomeContender.Name);
            }

            //check valid name for contender 2
            if (string.IsNullOrWhiteSpace(match.AwayContender.Name))
            {
                throw new ArgumentNullException(match.AwayContender.Name);
            }

            //check valid score
            if (match.HomeContender.Score < 0 || match.AwayContender.Score < 0)
            {
                throw new Exception("Score not valid");
            }

            _matches.AddOrUpdate(match.GetHash(), match, (k, v) => match);
        }
    }
}
