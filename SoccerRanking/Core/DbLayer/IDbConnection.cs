using System.Threading.Tasks;
using SoccerRanking.Core.Models;
using System.Collections.Generic;

namespace SoccerRanking.Core.DbLayer
{
    public interface IDbConnection
    {
        Task<IEnumerable<Team>> GetAllTeams();

        Task<IEnumerable<Player>> GetAllPlayers(int teamID);
    }
}
