using System.Data.SqlClient;

namespace SoccerRanking.Core.DbLayer
{
    public interface ISqlFactory
    {
        SqlConnection Create();
    }
}
