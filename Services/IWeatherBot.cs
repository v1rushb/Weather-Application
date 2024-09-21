using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces {
    public interface IWeatherBot {
        bool IsEnabled { get; set; }
        void Update(WeatherStateDTO data);
    }
}