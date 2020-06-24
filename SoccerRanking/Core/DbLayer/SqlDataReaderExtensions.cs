using System.Data.SqlClient;

namespace SoccerRanking.Core.DbLayer
{
    public static class SqlDataReaderExtensions
    {
        public static T GetValue<T>(this SqlDataReader reader, string columnName)
        {
            try
            {
                var rawValue = reader[columnName];
                return (T)rawValue;
            }
            catch
            {
                return default;
            }
        }
    }
}
