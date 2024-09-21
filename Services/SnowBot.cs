using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services.Bots
{
    public class SnowBot : IWeatherBot, IWeatherDataObserver
    {
        public bool IsEnabled { get; set; }
        private double TemperatureThreshold { get; }
        private string? Message { get; }

        public SnowBot(BotConfigDTO config)
        {
            IsEnabled = config.IsEnabled;
            TemperatureThreshold = config.Threshold;
            Message = config.Message;
        }

        public void Update(WeatherStateDTO data)
        {
            if (data.Temperature <= TemperatureThreshold)
            {
                ActivateBot();
            }
        }

        private void ActivateBot()
        {
            System.Console.WriteLine("SnowBot activated!");
            System.Console.WriteLine($"SnowBot: \"{Message}\"");
        }
    }
}
