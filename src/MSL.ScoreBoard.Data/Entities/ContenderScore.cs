namespace MSL.ScoreBoard.Data.Entities
{
    public class ContenderScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public ContenderScore(string name) => Name = name;

        public void Score_Update(int? score) => Score = score ?? 0;
    }
}
