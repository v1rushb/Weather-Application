using WeatherApp.Models;

namespace WeatherApp.Interfaces {
    public interface IInputParser {
        WeatherStateDTO? Parse(string input);

        bool CanParse(string input);
    }
}