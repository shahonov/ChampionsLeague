using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SoccerRanking.Core.DbLayer
{
    public class InitialSqlScriptsExecutor
    {
        private readonly ISqlFactory _sql;

        public InitialSqlScriptsExecutor(ISqlFactory factory)
        {
            this._sql = factory;
        }

        public async Task<bool> ExecuteScripts(bool useDb)
        {
            if (!useDb)
            {
                return true;
            }

            var allScripts = Directory.EnumerateFiles("./SqlScripts");

            try
            {
                using (var connection = this._sql.Create())
                {
                    await connection.OpenAsync();
                    foreach (var scriptFilePath in allScripts)
                    {
                        var scriptLines = File.ReadAllLines(scriptFilePath);
                        var script = string.Join(" ", scriptLines);
                        using (var cmd = new SqlCommand(script, connection))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
