using AspNetRestApiContainer.Application.Parameters;
using AspNetRestApiContainer.Application.Parameters.Queries;
using AspNetRestApiContainer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetRestApiContainer.Application.Interfaces.Repositories
{
    public interface IRectangleRepositoryAsync : IGenericRepositoryAsync<Rectangle>
    {
        Task<(IEnumerable<Rectangle> data, RecordsCount recordsCount)> GetPagedRectangleReponseAsync(GetRectangleQuery requestParameters);
    }
}