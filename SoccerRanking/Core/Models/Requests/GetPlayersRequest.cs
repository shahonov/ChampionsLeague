using MediatR;
using System.Collections.Generic;

namespace SoccerRanking.Core.Models.Requests
{
    public class GetPlayersRequest : IRequest<IEnumerable<Player>>
    {
        public GetPlayersRequest(int teamID, bool useDb)
        {
            this.TeamID = teamID;
            this.UseDb = useDb;
        }

        public int TeamID { get; set; }

        public bool UseDb { get; set; }
    }
}
