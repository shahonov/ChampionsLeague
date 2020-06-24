using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SoccerRanking.Core.Models;
using SoccerRanking.Core.Static;
using System.Collections.Generic;
using SoccerRanking.Core.DbLayer;
using SoccerRanking.Core.Models.Requests;

namespace SoccerRanking.Core.Handlers
{
    public class GetTeamsHandler : IRequestHandler<GetTeamsRequest, IEnumerable<Team>>
    {
        private readonly IDbConnection _db;
        private readonly MockData _mock;

        public GetTeamsHandler(IDbConnection connection)
        {
            this._db = connection;
            this._mock = new MockData();
        }

        public Task<IEnumerable<Team>> Handle(GetTeamsRequest request, CancellationToken cancellationToken)
        {
            if (request.UseMock)
            {
                return Task.FromResult(this._mock.GetTeams());
            }

            return this._db.GetAllTeams();
        }
    }
}
