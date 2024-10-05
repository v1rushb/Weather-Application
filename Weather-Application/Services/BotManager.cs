using System.Collections;
using WeatherApp.Models;
using WeatherApp.Repositories;
using WeatherApp.Services.Bots;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services 
{
    public class BotManager {
        private Dictionary<string, BotConfigDTO> _bots = BotConfigRepository.Instance.BotsConfig;

        private List<IWeatherBot> _enabledBots {
            get => GetBotsList()
                .Where(bot => bot.IsEnabled)
                                .ToList();
        }

        public void NotifyBots(WeatherStateDTO weatherData) {
            foreach(var bot in _enabledBots) {
                bot.Update(weatherData);
            }
        }
        private List<IWeatherBot> GetBotsList() {
            var bots = new List<IWeatherBot>();
            foreach(var config in _bots) 
            {
                switch(config.Key) 
                {
                case "RainBot":
                    bots.Add(new RainBot(config.Value));
                    break;
                case "SunBot":
                    bots.Add(new SunBot(config.Value));
                    break;
                case "SnowBot":
                    bots.Add(new SnowBot(config.Value));
                    break;
                default:
                    Console.WriteLine($"Unknown bot: {config.Key}");
                    break;
                }
            }
            return bots;
        }

    }
}