namespace SoccerRanking.Core
{
    public interface IDataSourceProvider
    {
        bool UseDb { get; set; }

        bool ChangeDataSource(bool useDb);
    }
}
