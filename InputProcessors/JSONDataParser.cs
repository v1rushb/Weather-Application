using Newtonsoft.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.InputDataParser {
    public class JSONDataParser : IInputParser {
        public WeatherStateDTO? Parse(String input) {
            return JsonConvert.DeserializeObject<WeatherStateDTO>(input);
        }
    }
}