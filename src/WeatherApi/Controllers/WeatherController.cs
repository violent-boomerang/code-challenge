using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{
		private ISender _mediator;

		private readonly ILogger<WeatherController> _logger;

		public WeatherController(ILogger<WeatherController> logger, ISender mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet("temperature")]
		public async Task<ActionResult<TemperatureDto>> GetTemperatureByLocation([FromQuery] string city)
		{
			var query = new GetTemperatureByCityQuery();
			return await _mediator.Send(query);
		}
	}
}
