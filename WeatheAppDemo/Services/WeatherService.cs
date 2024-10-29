using WeatheAppDemo.Models;

namespace WeatheAppDemo.Services
{
    public class WeatherService : IWeatherService
    {
        public List<CityWeather> _cityWeathers { get; set; }

        public WeatherService()
        {
            _cityWeathers = new List<CityWeather>()
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
                new CityWeather{CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather{CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };
        }

        public CityWeather? GetWeatherByCityCode(string CityCode)
        {
            var city = _cityWeathers.FirstOrDefault(w => w.CityUniqueCode == CityCode);

            return city;
        }

        public List<CityWeather> GetWeatherDetails()
        {
            List<CityWeather> cityWeathers = _cityWeathers;

            return cityWeathers;
        }
    }
}
