namespace SoccerRanking.Core
{
    public class DataSourceProvider : IDataSourceProvider
    {
        public DataSourceProvider(bool useDb)
        {
            this.UseDb = useDb;
        }

        public bool UseDb { get; set; }

        public bool ChangeDataSource(bool useDb)
        {
            this.UseDb = useDb;
            return true;
        }
    }
}
