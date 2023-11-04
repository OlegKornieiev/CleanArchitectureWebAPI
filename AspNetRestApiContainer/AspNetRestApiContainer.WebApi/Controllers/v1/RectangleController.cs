using AspNetRestApiContainer.Application.Parameters.Commands;
using AspNetRestApiContainer.Application.Parameters.Queries;
using AspNetRestApiContainer.Infrastructure.Shared.Services;
using AspNetRestApiContainer.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRectangleQuery filter)
        {
            var rectangleResponse = await _rectangleService.GetRectangles(filter);
            return Ok(rectangleResponse);
        }
    }
}