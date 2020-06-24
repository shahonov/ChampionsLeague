using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SoccerRanking.Core.Static;
using SoccerRanking.Core.Models;
using System.Collections.Generic;
using SoccerRanking.Core.DbLayer;
using SoccerRanking.Core.Models.Requests;

namespace SoccerRanking.Core.Handlers
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, IEnumerable<Player>>
    {
        private readonly IDbConnection _db;
        private readonly MockData _mock;

        public GetPlayersHandler(IDbConnection connection)
        {
            this._db = connection;
            this._mock = new MockData();
        }

        public Task<IEnumerable<Player>> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
        {
            if (request.UseMock)
            {
                var allPlayers = this._mock.GetPlayers();
                var filtered = allPlayers.Where(x => x.TeamID == request.TeamID);
                return Task.FromResult(filtered);
            }

            return this._db.GetAllPlayers(request.TeamID);
        }
    }
}
