using MediatR;
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

        public TeamsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeams()
        {
            // if available db - change to useMock: false
            var request = new GetTeamsRequest(useMock: true);
            var response = await this._mediator.Send(request);

            return this.Ok(response);
        }
    }
}
