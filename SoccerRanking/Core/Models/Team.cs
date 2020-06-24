namespace SoccerRanking.Core.Models
{
    public class Team
    {
        public Team(int id, string name, int w, int d, int l)
        {
            this.ID = id;
            this.Name = name;
            this.Wins = w;
            this.Draws = d;
            this.Losses = l;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int Points => (this.Wins * 3) + this.Draws;
    }
}
