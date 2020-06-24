using SoccerRanking.Core.Models.Enums;

namespace SoccerRanking.Core.Models
{
    public class Player
    {
        public Player(int id, string name, int teamID, PlayerRole role, int sg, int yc, int rc)
        {
            this.ID = id;
            this.Name = name;
            this.TeamID = teamID;
            this.Role = role;
            this.ScoredGoals = sg;
            this.YellowCards = yc;
            this.RedCards = rc;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int TeamID { get; set; }

        public PlayerRole Role { get; set; }

        public int ScoredGoals { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }
    }
}
