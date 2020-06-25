using SoccerRanking.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SoccerRanking.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataSourceController : Controller
    {
        private readonly IDataSourceProvider _dataSourceProvider;

        public DataSourceController(IDataSourceProvider dataSource)
        {
            this._dataSourceProvider = dataSource;
        }

        [HttpGet("{useDb}")]
        public IActionResult ChangeDataSource(bool useDb)
        {
            var response = this._dataSourceProvider.ChangeDataSource(useDb);
            if (response)
            {
                return this.Ok(response);
            }
            else
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
