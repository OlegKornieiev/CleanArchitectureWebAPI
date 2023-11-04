using AspNetRestApiContainer.Application.Parameters.Queries;
using AspNetRestApiContainer.Domain.Entities;
using AspNetRestApiContainer.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetRestApiContainer.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("rectangle")]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;

        public RectangleController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        /// <summary>
        /// GET: api/controller
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("findRectangles")]
        public async Task<IActionResult> FindRectangles([FromBody] List<Coordinate> filter)
        {
            var request = new GetRectangleQuery() { Coordinates = filter };
            var rectangleResponse = await _rectangleService.GetRectangles(request);
            return Ok(rectangleResponse);
        }
    }
}