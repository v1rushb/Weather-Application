using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces {
    public interface IWeatherBot {
        bool IsEnabled { get; set; }
        public bool isTriggered { get; set; }
        void Update(WeatherStateDTO data);
    }
}