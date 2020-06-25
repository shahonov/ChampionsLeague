using MediatR;
using SoccerRanking.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerRanking.Core.Models.Requests;

namespace SoccerRanking.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDataSourceProvider _dataSourceProvider;

        public TeamsController(IMediator mediator, IDataSourceProvider dataSource)
        {
            this._mediator = mediator;
            this._dataSourceProvider = dataSource;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeams()
        {
            var request = new GetTeamsRequest(this._dataSourceProvider.UseDb);
            var response = await this._mediator.Send(request);

            return this.Ok(response);
        }
    }
}
