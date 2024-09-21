using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Strategies 
{
    public class WeatherStrategyContext
    {
        private IInputParser? _inputProcessStrategy;

        public WeatherStrategyContext() {}

        public WeatherStrategyContext(IInputParser inputProcessStrategy) 
        {
            _inputProcessStrategy = inputProcessStrategy;
        }

        public void SetProcessingStrategy(IInputParser strategy) 
        {
            _inputProcessStrategy = strategy;
        }

        public WeatherStateDTO? WeatherDeserialize(string input) => _inputProcessStrategy?.Parse(input);
        public bool CanParse(string input) => _inputProcessStrategy?.CanParse(input) ?? false;

    } 
}