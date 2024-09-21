using Newtonsoft.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.InputDataParser.Strategies 
{
    public class JSONDataParser : IInputParser 
    {
        public WeatherStateDTO? Parse(String input) => JsonConvert.DeserializeObject<WeatherStateDTO>(input);
    }
}