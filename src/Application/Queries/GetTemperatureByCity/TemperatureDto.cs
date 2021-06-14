using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class TemperatureDto
	{
		public decimal Value { get; set; }
		public TemperatureUnit Unit { get; set; }
	}
}
