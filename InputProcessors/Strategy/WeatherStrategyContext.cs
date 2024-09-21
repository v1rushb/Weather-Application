using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Strategies 
{
    public abstract class WeatherStrategyContext(IInputParser inputProcessStrategy)
    {
        private IInputParser _inputProcessStrategy = inputProcessStrategy;

        public void SetProcessingStrategy(IInputParser strategy) 
        {
            _inputProcessStrategy = strategy;
        }

        public WeatherStateDTO? WeatherDeserialize(string input) => _inputProcessStrategy.Parse(input);
    } 
}