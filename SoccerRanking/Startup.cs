using System;
using MediatR;
using System.Threading.Tasks;
using SoccerRanking.Core.DbLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using SoccerRanking.Core;

namespace SoccerRanking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var useDb = bool.Parse(this.Configuration["Settings:UseDb"]);
            var connectionString = this.Configuration["Settings:ConnectionString"];
            services
                .AddMediatR(typeof(Startup))
                .AddDatabase(connectionString)
                .AddServices(useDb);

            var provider = services.BuildServiceProvider();
            var factory = provider.GetService<ISqlFactory>();
            var dataSource = provider.GetService<IDataSourceProvider>();
            var isComplete = this.InitSqlStructure(factory, dataSource).Result;
            if (!isComplete)
            {
                var message = "Error creating initial sql sctructure. " +
                    "Check SqlScripts Folder or InitialSqlScriptsExecutor.cs file.";
                throw new Exception(message);
            }

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private async Task<bool> InitSqlStructure(ISqlFactory factory, IDataSourceProvider dataSourceProvider)
        {
            var executor = new InitialSqlScriptsExecutor(factory);
            return await executor.ExecuteScripts(useDb: dataSourceProvider.UseDb);
        }
    }
}
