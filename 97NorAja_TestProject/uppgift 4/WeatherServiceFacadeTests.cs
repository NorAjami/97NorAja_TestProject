using _97NorAja_TestProject.Uppgift4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute; // För att mocka WeatherClient
using NSubstitute.ExceptionExtensions;
using System.Net.Http;
using System.Threading.Tasks;


namespace _97NorAja_TestProject.Uppgift4
{
    [TestClass]
    public class WeatherServiceFacadeTests
    {
        [TestMethod]
        public async Task GetWeather_ShouldReturnCorrectWeatherData_ForValidCity()
        {
            // ARRANGE
            var mockWeatherClient = Substitute.For<WeatherClient>(new HttpClient());
            mockWeatherClient.GetCurrentWeatherAsync("Stockholm").Returns(Task.FromResult("Sunny 25°C"));

            var facade = new WeatherServiceFacade(mockWeatherClient);

            // ACT
            var result = await facade.GetWeather("Stockholm");

            // ASSERT
            Assert.AreEqual("Current weather in Stockholm: Sunny 25°C", result);
        }

        [TestMethod]
        public async Task GetWeather_ShouldReturnErrorMessage_WhenCityIsNull()
        {
            // ARRANGE
            var mockWeatherClient = Substitute.For<WeatherClient>(new HttpClient());
            var facade = new WeatherServiceFacade(mockWeatherClient);

            // ACT
            var result = await facade.GetWeather(null);

            // ASSERT
            Assert.AreEqual("Invalid city name", result);
        }

        [TestMethod]
        public async Task GetWeather_ShouldReturnErrorMessage_WhenHttpRequestFails()
        {
            // ARRANGE
            var mockWeatherClient = Substitute.For<WeatherClient>(new HttpClient());
            mockWeatherClient.GetCurrentWeatherAsync("Gothenburg")
                             .Throws(new HttpRequestException("Network error"));

            var facade = new WeatherServiceFacade(mockWeatherClient);

            // ACT
            var result = await facade.GetWeather("Gothenburg");

            // ASSERT
            Assert.AreEqual("Could not fetch weather data. Please try again later.", result);
        }

        [TestMethod]
        public async Task GetWeather_ShouldHandleLongCityNames()
        {
            // ARRANGE
            var mockWeatherClient = Substitute.For<WeatherClient>(new HttpClient());
            var longCityName = new string('a', 500); // 500 tecken lång stad
            mockWeatherClient.GetCurrentWeatherAsync(longCityName).Returns(Task.FromResult("Cloudy 10°C"));

            var facade = new WeatherServiceFacade(mockWeatherClient);

            // ACT
            var result = await facade.GetWeather(longCityName);

            // ASSERT
            Assert.AreEqual($"Current weather in {longCityName}: Cloudy 10°C", result);
        }
    }
}
