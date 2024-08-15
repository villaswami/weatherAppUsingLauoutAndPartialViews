using Microsoft.AspNetCore.Mvc;

using WeatherAppWithPartialView.Models;
namespace WeatherAppWithPartialView.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeather> cities = new List<CityWeather>() {
    new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

    new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

    new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
   };
        [Route("/")]
        public IActionResult Index()
        {
            //send cities collection to "Views/Weather/Index" view
            return View(cities);
        }


        [Route("weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {

            if (string.IsNullOrEmpty(cityCode))
            {

                return View();
            }


            CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();


            return View(city);
        }

    }
}
