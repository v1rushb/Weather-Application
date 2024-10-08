using System.Xml.Serialization;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.InputDataParser.Strategies 
{
    public class XMLDataParser : IInputParser 
    {
        public WeatherStateDTO? Parse(string input) 
        {
            var serializer = new XmlSerializer(typeof(WeatherStateDTO));
            using var reader = new StringReader(input);
            return (WeatherStateDTO?) serializer.Deserialize(reader);
        }
        public bool CanParse(string input) => input.TrimStart().StartsWith("<");
    }
}