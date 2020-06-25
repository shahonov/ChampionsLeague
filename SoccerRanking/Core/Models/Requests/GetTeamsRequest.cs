using MediatR;
using System.Collections.Generic;

namespace SoccerRanking.Core.Models.Requests
{
    public class GetTeamsRequest : IRequest<IEnumerable<Team>> 
    {
        public GetTeamsRequest(bool useDb)
        {
            this.UseDb = useDb;
        }

        public bool UseDb { get; set; }
    }
}
