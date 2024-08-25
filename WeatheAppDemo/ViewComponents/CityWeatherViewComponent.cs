using Microsoft.AspNetCore.Mvc;
using WeatheAppDemo.Models;

namespace WeatheAppDemo.ViewComponents
{
    public class CityWeatherViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(CityWeather cityWeather, string color)
        {
            ViewBag.color = color;
            return View("CityWeather", cityWeather);
        }

    }
}
