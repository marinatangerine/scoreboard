namespace MSL.ScoreBoard.Data.Entities
{
    public class ContenderScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public ContenderScore(string name) => Name = name;
    }
}
