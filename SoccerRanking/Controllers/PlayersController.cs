using MediatR;
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

        public PlayersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{teamID}")]
        public async Task<IActionResult> GetAllPlayers(int teamID)
        {
            // if available db - change to useMock: false
            var request = new GetPlayersRequest(teamID, useMock: true);
            var response = await this._mediator.Send(request);

            return this.Ok(response);
        }
    }
}
