using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services.Bots
{
    public class RainBot : IWeatherBot, IWeatherDataObserver
    {
        public bool IsEnabled { get; set; }
        private double HumidityThreshold { get; }
        private string? Message { get; }

        public bool isTriggered {get; set; }

        public RainBot(BotConfigDTO config)
        {
            IsEnabled = config.IsEnabled;
            HumidityThreshold = config.Threshold;
            Message = config.Message;
        }

        public void Update(WeatherStateDTO data)
        {
            if (data.Humidity >= HumidityThreshold)
            {
                ActivateBot();
                isTriggered = true;
                return;
            }
            isTriggered = false;
        }

        private void ActivateBot()
        {
            System.Console.WriteLine("RainBot activated!");
            System.Console.WriteLine($"RainBot: \"{Message}\"");
        }
    }
}
