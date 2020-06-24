using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SoccerRanking.Core.Models;
using SoccerRanking.Core.Models.Enums;

namespace SoccerRanking.Core.DbLayer
{
    public class DbConnection : IDbConnection
    {
        private readonly ISqlFactory _sql;

        public DbConnection(ISqlFactory factory)
        {
            this._sql = factory;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers(int teamID)
        {
            try
            {
                using (var connection = this._sql.Create())
                {
                    await connection.OpenAsync();
                    using (var cmd = new SqlCommand("prcGetPlayers", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.AddWithValue("TeamID", teamID);
                        var reader = await cmd.ExecuteReaderAsync();
                        var players = await this.ParsePlayers(reader);
                        return players;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = $"Error occured while reading players for team:[{teamID}] from database: {ex.Message}";
                Console.WriteLine(message);
                // audit log message somewhere
                return new List<Player>();
            }
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            try
            {
                using (var connection = this._sql.Create())
                {
                    await connection.OpenAsync();
                    using (var cmd = new SqlCommand("prcGetTeams", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        var teams = await this.ParseTeams(reader);
                        return teams;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = $"Error occured while reading teams from database: {ex.Message}";
                Console.WriteLine(message);
                // audit log message somewhere
                return new List<Team>();
            }
        }

        private async Task<IEnumerable<Player>> ParsePlayers(SqlDataReader reader)
        {
            var players = new List<Player>();

            while (await reader.ReadAsync())
            {
                var id = reader.GetValue<int>("ID");
                var name = reader.GetValue<string>("Name");
                var teamID = reader.GetValue<int>("TeamID");
                var roleStr = reader.GetValue<string>("Role");
                var role = PlayerRole.Half;
                if (Enum.TryParse(roleStr, out PlayerRole parsed))
                {
                    role = parsed;
                }
                var scoredGoals = reader.GetValue<int>("ScoredGoals");
                var yellowCards = reader.GetValue<int>("YellowCards");
                var redCards = reader.GetValue<int>("RedCards");

                var player = new Player(id, name, teamID, role, scoredGoals, yellowCards, redCards);
                players.Add(player);
            }

            return players;
        }

        private async Task<IEnumerable<Team>> ParseTeams(SqlDataReader reader)
        {
            var teams = new List<Team>();

            while (await reader.ReadAsync())
            {
                var id = reader.GetValue<int>("ID");
                var name = reader.GetValue<string>("Name");
                var wins = reader.GetValue<int>("Wins");
                var draws = reader.GetValue<int>("Draws");
                var losses = reader.GetValue<int>("Losses");

                var team = new Team(id, name, wins, draws, losses);
                teams.Add(team);
            }

            return teams;
        }
    }
}
