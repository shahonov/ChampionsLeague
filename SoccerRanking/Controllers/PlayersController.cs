using MediatR;
using SoccerRanking.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerRanking.Core.Models.Requests;

namespace SoccerRanking.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDataSourceProvider _dataSourceProvider;

        public PlayersController(IMediator mediator, IDataSourceProvider dataSource)
        {
            this._mediator = mediator;
            this._dataSourceProvider = dataSource;
        }

        [HttpGet("{teamID}")]
        public async Task<IActionResult> GetAllPlayers(int teamID)
        {
            var request = new GetPlayersRequest(teamID, this._dataSourceProvider.UseDb);
            var response = await this._mediator.Send(request);

            return this.Ok(response);
        }
    }
}
