using WeatheAppDemo.Models;

namespace WeatheAppDemo.Services
{
    public interface IWeatherService
    {

        List<CityWeather> GetWeatherDetails();

        CityWeather? GetWeatherByCityCode(string CityCode);

    }
}
