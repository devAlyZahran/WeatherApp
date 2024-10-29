using Microsoft.AspNetCore.Mvc;
using WeatheAppDemo.Models;
using WeatheAppDemo.Services;

namespace WeatheAppDemo.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = _weatherService.GetWeatherDetails();
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

            CityWeather? cityWeather = _weatherService.GetWeatherByCityCode(cityCode);

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
