using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Application.Models;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _apiClient;
		private readonly OpenWeatherApiSettings _settings;
		private readonly ILogger<ApiService> _logger;

		public ApiService(IHttpClientFactory httpClientFactory, IOptions<OpenWeatherApiSettings> settings, ILogger<ApiService> logger)
		{
			_apiClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.WEATHER_API_CLIENT);
			_settings = settings.Value;
			_logger = logger;
		}

		public async Task<ApiResponse> GetTemperatureByCity(string cityName)
		{
			// https://api.openweathermap.org/data/2.5/weather?q=London&appid=6b34b4b2b9b20b3af3530f12a8a7723e

			var endpoint = $"weather?q={cityName}&appid={_settings.Key}";

			using var requestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
			var response = await _apiClient.SendAsync(requestMessage);

			if (response.StatusCode != HttpStatusCode.OK)
				throw new HttpListenerException();

			var res = await response.Content
						.ReadAsStringAsync();

			var result = JsonSerializer
				.Deserialize<ApiResponse>(res);

			return result;

		}
	}
}
