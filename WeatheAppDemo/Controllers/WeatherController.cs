using Microsoft.AspNetCore.Mvc;
using WeatheAppDemo.Models;

namespace WeatheAppDemo.Controllers
{
    public class WeatherController : Controller
    {
        public List<CityWeather> CityWeathers { get; set; }

        public WeatherController()
        {
            CityWeathers = new List<CityWeather>()
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
                new CityWeather{CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = CityWeathers.ToList();
            //List<CityWeather> cityWeathers = null;

            if (cityWeathers == null || cityWeathers.Count == 0)
            {
                ViewBag.Msg = "There's no items!!";
                return View("Error");
            }

            return View(cityWeathers);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return NotFound();
            }

            CityWeather? cityWeather = CityWeathers.Where(w => w.CityUniqueCode == cityCode)?.FirstOrDefault();

            if (cityWeather == null)
            {
                return BadRequest();
            }
            else
            {
                return View(cityWeather);
            }
        }

    }
}
