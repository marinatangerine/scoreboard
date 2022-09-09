using MSL.ScoreBoard.Data.Extensions;
using System.Collections.Concurrent;

namespace MSL.ScoreBoard.Data.Entities
{
    public class Scoreboard
    {
        private ConcurrentDictionary<int, Match> _matches { get; set; }
        private ConcurrentDictionary<int, ContenderScore> _contenders;

        public Scoreboard()
        {
            _matches = new ConcurrentDictionary<int, Match>();
            _contenders = new ConcurrentDictionary<int, ContenderScore>();
        }

        #region Public methods
        public void Match_Start(string homeContender, string awayContender)
        {
            var match = new Match(homeContender, awayContender);
            Validate_Match_Start(match);
            _matches.AddOrUpdate(match.GetHash(), match, (k, v) => match);

            //add both contenders to list of contenders
            Contender_Add(match.HomeContender);
            Contender_Add(match.AwayContender);
        }

        public void Match_End(string homeContender, string awayContender)
        {
            var match = new Match(homeContender, awayContender);
            Validate_Match_End(match);
            _matches.TryRemove(match.GetHash(), out var ignored);

            //remove both contenders from contenders list
            Contender_Remove(match.HomeContender);
            Contender_Remove(match.AwayContender);
        }

        public void Match_Update(string homeContender, string awayContender, int homeScore, int awayScore)
        {
            var match = new Match(homeContender, awayContender);
            match.Score_Update(homeScore, awayScore);
            Validate_Match_Update(match);
            _matches.AddOrUpdate(match.GetHash(), match, (k, v) => match);
        }

        public IEnumerable<Match> ScoreBoard_List()
            => _matches.Values.OrderByDescending(q => q.HomeContender.Score + q.AwayContender.Score).ThenByDescending(q => q.StartTime);
        #endregion Public methods

        #region Private
        private void Contender_Remove(ContenderScore contender)
        {
            _contenders.TryRemove(contender.Name.GetHashCode(), out var ignore);
        }

        private void Contender_Add(ContenderScore contender)
        {
            _contenders.TryAdd(contender.Name.GetHashCode(), contender);
        }

        private void Validate_Match_Start(Match match)
        {
            Validate_Contenders(match);

            //check match doesn't exist
            var matchKey = match.GetHash();
            if (_matches.ContainsKey(matchKey))
            {
                throw new Exception("Match already exists");
            }

            //check home contender not in any match
            if (_contenders.ContainsKey(match.HomeContender.Name.GetHashCode()))
            {
                throw new Exception("Invalid contender");
            }

            //check away contender not in any match
            if (_contenders.ContainsKey(match.AwayContender.Name.GetHashCode()))
            {
                throw new Exception("Invalid contender");
            }
        }

        private void Validate_Match_Update(Match match)
        {
            Validate_Contenders(match);
            Validate_Scores(match);

            //check match exists
            var matchKey = match.GetHash();
            if (!_matches.ContainsKey(matchKey))
            {
                throw new Exception("Match not found");
            }
        }

        private void Validate_Match_End(Match match)
        {
            Validate_Contenders(match);

            //check match exists
            var matchKey = match.GetHash();
            if (!_matches.ContainsKey(matchKey))
            {
                throw new Exception("Match not found");
            }
        }

        private void Validate_Contenders(Match match)
        {
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
        }

        private void Validate_Scores(Match match)
        {
            //check valid score
            if (match.HomeContender.Score < 0 || match.AwayContender.Score < 0)
            {
                throw new Exception("Score not valid");
            }
        }
        #endregion Private

    }
}
