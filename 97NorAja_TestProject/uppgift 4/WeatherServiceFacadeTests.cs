using _97NorAja_TestProject.uppgift_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject.Uppgift4.Tests
{
    public class WeatherServiceFacadeTests
    {
        [TestClass]
        public class WeatherServiceFacadeTests
        {
            [TestMethod]
            public async Task GetWeather_ShouldReturnErrorMessage_WhenCityIsInvalid()
            {
                // ARRANGE
                var mockWeatherClient = new WeatherClient(new HttpClient());
                var facade = new WeatherServiceFacade(mockWeatherClient);

                // ACT
                var result = await facade.GetWeather("");

                // ASSERT
                Assert.AreEqual("Invalid city name", result);
            }
        }
    }
}

