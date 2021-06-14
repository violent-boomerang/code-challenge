using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class GetTemperatureByCityQueryHandler : IRequestHandler<GetTemperatureByCityQuery, TemperatureDto>
	{

		private readonly IApiService _api;

		public GetTemperatureByCityQueryHandler(IApiService api)
		{
			_api = api;
		}

		public Task<TemperatureDto> Handle(GetTemperatureByCityQuery request, CancellationToken cancellationToken)
		{
			var res = _api.GetTemperatureByCity(request.CityName);
			throw new NotImplementedException();

		}
	}
}
