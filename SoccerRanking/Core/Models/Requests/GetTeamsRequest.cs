using MediatR;
using System.Collections.Generic;

namespace SoccerRanking.Core.Models.Requests
{
    public class GetTeamsRequest : IRequest<IEnumerable<Team>> 
    {
        public GetTeamsRequest(bool useMock)
        {
            this.UseMock = useMock;
        }

        public bool UseMock { get; set; }
    }
}
