using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // Behövs för HttpRequestException och HttpClient


namespace _97NorAja_TestProject.Uppgift4
{
    public class WeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;

        // Konstruktor som tar in en HttpClient (Dependency Injection)
        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // Metod som hämtar väderdata för en given stad
        public async Task<string> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City name cannot be null or empty.", nameof(city));

            try
            {
                // Simulerar ett API-anrop för att hämta väderdata
                var response = await _httpClient.GetAsync($"https://api.weather.com/current?city={city}");

                response.EnsureSuccessStatusCode(); // Kasta undantag om statuskoden inte är 2xx

                var weatherData = await response.Content.ReadAsStringAsync();
                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                // Hantera nätverksfel genom att kasta ett undantag
                throw new HttpRequestException("Error fetching weather data", ex);
            }
        }
    }
}
