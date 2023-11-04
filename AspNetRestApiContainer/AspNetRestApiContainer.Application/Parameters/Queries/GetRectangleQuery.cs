using AspNetRestApiContainer.Domain.Entities;
using System.Collections.Generic;

namespace AspNetRestApiContainer.Application.Parameters.Queries
{
    public class GetRectangleQuery : QueryParameter
    {
        public List<Coordinate> Coordinates { get; set; }
    }
}