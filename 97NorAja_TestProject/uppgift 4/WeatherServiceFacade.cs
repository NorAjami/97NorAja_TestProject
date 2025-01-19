using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using Xunit;
using System.Net.Http; // För HttpClient och HttpRequestException
using System.Threading.Tasks; // För Task


namespace _97NorAja_TestProject.Uppgift4
{
    
    public class WeatherServiceFacade
    {
        private readonly IWeatherClient _weatherClient;

        // Konstruktor som tar in en instans av IWeatherClient (Dependency Injection)
        public WeatherServiceFacade(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient ?? throw new ArgumentNullException(nameof(weatherClient));
        }

        // Metod som hämtar väderinformation för en given stad
        public async Task<string> GetWeather(string city)
        {
            // Kontrollera om stadnamnet är tomt eller null
            if (string.IsNullOrWhiteSpace(city))
            {
                return "Invalid city name";
            }

            try
            {
                // Anropa IWeatherClient för att hämta väderdata
                var weatherData = await _weatherClient.GetCurrentWeatherAsync(city);

                // Returnera en formatterad sträng med väderinformationen
                return $"Current weather in {city}: {weatherData}";
            }
            catch (HttpRequestException)
            {
                // Hantera nätverksfel genom att returnera ett användarvänligt meddelande
                return "Could not fetch weather data. Please try again later.";
            }
        }

    }
}