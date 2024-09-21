using System.Timers;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Repositories {
    public class BotConfigRepository {
        private static readonly BotConfigRepository _instance = new BotConfigRepository();
        private const string _configFilePath = @"Config/BotsConfig.json";
        public static BotConfigRepository Instance => _instance;

        private Dictionary<string, BotConfigDTO> _bots;

        public Dictionary<string, BotConfigDTO> BotsConfig { get => _bots; }


        private BotConfigRepository() {
            LoadConfigFromFile(_configFilePath);
        }
        private void LoadConfigFromFile(string path) {
            string configJson = File.ReadAllText(path);
            _bots = JsonConvert.DeserializeObject<Dictionary<string, BotConfigDTO>>(configJson);
        }
    }
}