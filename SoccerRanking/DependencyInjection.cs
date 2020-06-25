using SoccerRanking.Core;
using SoccerRanking.Core.DbLayer;
using Microsoft.Extensions.DependencyInjection;

namespace SoccerRanking
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, bool useDb)
        {
            services.AddSingleton<IDataSourceProvider>(_ => new DataSourceProvider(useDb));
            services.AddSingleton<IDbConnection, DbConnection>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ISqlFactory>(_ => new SqlFactory(connectionString));
            return services;
        }
    }
}
