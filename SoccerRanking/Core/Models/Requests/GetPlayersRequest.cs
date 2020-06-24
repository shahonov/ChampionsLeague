using MediatR;
using System.Collections.Generic;

namespace SoccerRanking.Core.Models.Requests
{
    public class GetPlayersRequest : IRequest<IEnumerable<Player>>
    {
        public GetPlayersRequest(int teamID, bool useMock)
        {
            this.TeamID = teamID;
            this.UseMock = useMock;
        }

        public int TeamID { get; set; }

        public bool UseMock { get; set; }
    }
}
