using AspNetRestApiContainer.Application.Interfaces.Repositories;
using AspNetRestApiContainer.Application.Parameters;
using AspNetRestApiContainer.Application.Parameters.Queries;
using AspNetRestApiContainer.Domain.Entities;
using AspNetRestApiContainer.Infrastructure.Persistence.Contexts;
using AspNetRestApiContainer.Infrastructure.Persistence.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace AspNetRestApiContainer.Infrastructure.Persistence.Repositories
{
    public class RectangleRepositoryAsync : GenericRepositoryAsync<Rectangle>, IRectangleRepositoryAsync
    {
        private readonly DbSet<Rectangle> _rectangles;

        public RectangleRepositoryAsync(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _rectangles = dbContext.Set<Rectangle>();
        }

        public async Task<(IEnumerable<Rectangle> data, RecordsCount recordsCount)> GetPagedRectangleReponseAsync(GetRectangleQuery requestParameter)
        {
            var coordinates = requestParameter.Coordinates;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            var result = _rectangles.AsNoTracking().AsExpandable();

            recordsTotal = await result.CountAsync();

            FilterByCoordinates(ref result, coordinates);

            recordsFiltered = await result.CountAsync();

            var recordsCount = new RecordsCount
            {
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            };

            if (!string.IsNullOrWhiteSpace(orderBy))
                result = result.OrderBy(orderBy);

            if (!string.IsNullOrWhiteSpace(fields))
                result = result.Select<Rectangle>("new(" + fields + ")");

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var resultData = await result.ToListAsync();

            return (resultData, recordsCount);
        }

        private static void FilterByCoordinates(ref IQueryable<Rectangle> rectangles, List<Coordinate> coordinates)
        {
            if (!rectangles.Any() || coordinates == null || coordinates.Count == 0)
                return;

            var predicate = PredicateBuilder.New<Rectangle>();

            foreach (var coordinate in coordinates)
            {
                predicate = predicate
                    .Or(p => p.X <= coordinate.X && p.X + p.Width >= coordinate.X && p.Y <= coordinate.Y && p.Y + p.Height >= coordinate.Y);
            }

            rectangles = rectangles.Where(predicate);
        }
    }
}