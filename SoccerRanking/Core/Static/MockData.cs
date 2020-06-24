using SoccerRanking.Core.Models;
using System.Collections.Generic;
using SoccerRanking.Core.Models.Enums;

namespace SoccerRanking.Core.Static
{
    public class MockData
    {
        public IEnumerable<Team> GetTeams()
        {
            var teams = new List<Team>()
            {
                new Team(1, "Barcelona", 5, 3, 2),
                new Team(2, "Real Madrid", 4, 4, 5),
                new Team(3, "Manchester United", 7, 2, 0),
                new Team(4, "Chelsea", 2, 6, 0),
                new Team(5, "Ludogorets", 1, 2, 6)
            };

            return teams;
        }

        public IEnumerable<Player> GetPlayers()
        {
            var players = new List<Player>()
            {
                new Player(1, "Messi", 1, PlayerRole.Attack, 2, 2, 0),
                new Player(2, "Ronaldinho", 1, PlayerRole.Attack, 2, 1, 1),
                new Player(3, "Pique", 1, PlayerRole.Defend, 0, 1, 0),
                new Player(4, "Stegen", 1, PlayerRole.GoalKeeper, 1, 0, 0),

                new Player(5, "Ronaldo", 2, PlayerRole.Attack, 2, 1, 0),
                new Player(6, "Ramos", 2, PlayerRole.Defend, 1, 2, 0),
                new Player(7, "Mendy", 2, PlayerRole.Defend, 1, 0, 0),
                new Player(8, "Areola", 2, PlayerRole.GoalKeeper, 0, 0, 0),

                new Player(9, "Rooney", 3, PlayerRole.Attack, 5, 0, 0),
                new Player(10, "Nistelrooy", 3, PlayerRole.Attack, 2, 0, 1),
                new Player(11, "Violet", 3, PlayerRole.Half, 0, 1, 1),
                new Player(12, "Romero", 3, PlayerRole.GoalKeeper, 0, 0, 0),

                new Player(13, "Drogba", 4, PlayerRole.Attack, 1, 0, 1),
                new Player(14, "Pulisic", 4, PlayerRole.Attack, 1, 1, 0),
                new Player(15, "Kante", 4, PlayerRole.Half, 0, 2, 0),
                new Player(16, "Arrizabalaga", 4, PlayerRole.GoalKeeper, 0, 1, 0),

                new Player(17, "Marcelinho", 5, PlayerRole.Attack, 1, 0, 0),
                new Player(18, "Souza", 5, PlayerRole.Half, 0, 2, 2),
                new Player(19, "Moti", 5, PlayerRole.Defend, 0, 0, 3),
                new Player(20, "Santos", 5, PlayerRole.GoalKeeper, 0, 0, 1)
            };

            return players;
        }
    }
}
