using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
	class GetTemperatureByCityQueryHandler : IRequestHandler<GetTemperatureByCityQuery, TemperatureDto>
	{
		public Task<TemperatureDto> Handle(GetTemperatureByCityQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
