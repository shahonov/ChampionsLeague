using System.Data.SqlClient;

namespace SoccerRanking.Core.DbLayer
{
    public class SqlFactory : ISqlFactory
    {
        private readonly string _connectionString;

        public SqlFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
