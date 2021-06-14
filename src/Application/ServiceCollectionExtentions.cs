using Application.Models;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public static class ServiceCollectionExtensions
	{
		public const string WEATHER_API_CLIENT = "WeatherAPIClient";

		public static IServiceCollection AddApplication(
			this IServiceCollection services,
			OpenWeatherApiSettings settings)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());

			services
				.AddHttpClient(
					WEATHER_API_CLIENT,
					client =>
					{
						client.BaseAddress = new Uri(settings.Url);
						client.DefaultRequestHeaders.Clear();
						//client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
					}
				);

			services.AddScoped<IApiService, ApiService>();

			return services;
		}
	}
}
