using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Application.Models;

namespace Application.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _apiClient;
		private readonly OpenWeatherApiSettings _settings;

		public ApiService(IHttpClientFactory httpClientFactory, IOptions<OpenWeatherApiSettings> settings)
		{
			_apiClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.WEATHER_API_CLIENT);
			_settings = settings.Value;
		}

		public int Test()
		{
			return 5;
		}
	}
}
