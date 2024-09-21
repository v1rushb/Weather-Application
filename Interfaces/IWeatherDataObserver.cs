using WeatherApp.Models;

namespace WeatherApp.Interfaces {
    public interface IWeatherDataObserver {
        void Update(WeatherStateDTO weatherData);
    }
}