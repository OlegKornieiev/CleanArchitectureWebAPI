using AspNetRestApiContainer.Application.Interfaces.Repositories;
using AspNetRestApiContainer.Application.Parameters.Queries;
using AspNetRestApiContainer.Application.Wrappers;
using AspNetRestApiContainer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetRestApiContainer.Infrastructure.Shared.Services
{
    public interface IRectangleService
    {
        Task<PagedResponse<IEnumerable<Rectangle>>> GetRectangles(GetRectangleQuery request);
    }

    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepositoryAsync _rectangleRepository;

        public RectangleService(
            IRectangleRepositoryAsync rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        public async Task<PagedResponse<IEnumerable<Rectangle>>> GetRectangles(GetRectangleQuery request)
        {
            var (data, recordsCount) = await _rectangleRepository.GetPagedRectangleReponseAsync(request);
            return new PagedResponse<IEnumerable<Rectangle>>(data, request.PageNumber, request.PageSize, recordsCount);
        }
    }
}
