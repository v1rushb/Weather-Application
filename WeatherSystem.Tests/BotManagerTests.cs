using AutoFixture;
using FluentAssertions;
using WeatherApp.Models;
using WeatherApp.Services.Bots;

namespace WeatherSystem.Tests {
    public class BotManagerTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public void RainBot_ShouldNotActivate_WhenHumidityIsBelowThreshold()
        {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(arg => arg.IsEnabled, true)
                                    .With(arg => arg.Threshold, 70)
                                    .With(arg => arg.Message, "Raing Goes brrrr")
                                    .Create();

            var rainBot = new RainBot(botConfig);
            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(arg => arg.Humidity, 69)
                                      .Create();

            rainBot.Update(weatherData);
            rainBot.isTriggered.Should().BeFalse();
        }

        [Fact]
        public void RainBot_ShouldActivate_WhenHumidityIsAboveThreshold()
        {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(arg => arg.IsEnabled, true)
                                    .With(arg => arg.Threshold, 70)
                                    .With(arg => arg.Message, "Raing Goes brrrr")
                                    .Create();

            var rainBot = new RainBot(botConfig);
            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(arg => arg.Humidity, 76)
                                      .Create();

            rainBot.Update(weatherData);
            rainBot.isTriggered.Should().BeTrue();
        }

        [Fact]
        public void SunBot_ShouldNotActivate_WhenTemperatureBelowThreshold()
        {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(arg => arg.IsEnabled, true)
                                    .With(arg => arg.Threshold, 30)
                                    .With(arg => arg.Message, "too cold brrrr")
                                    .Create();

            var sunBot = new SunBot(botConfig);
            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(arg => arg.Temperature, 25)
                                      .Create();

            sunBot.Update(weatherData);
            sunBot.isTriggered.Should().BeTrue();
        }

        [Fact]
        public void SunBot_ShouldActivate_WhenTemperatureAboveThreshold() {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(arg => arg.IsEnabled, true)
                                    .With(arg => arg.Threshold, 30)
                                    .With(arg => arg.Message, "Sun Goes brrrr")
                                    .Create();

            var sunBot = new SunBot(botConfig);
            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(arg => arg.Temperature, 31)
                                      .Create();

            sunBot.Update(weatherData);
            sunBot.isTriggered.Should().BeTrue();
        }

        [Fact]
        public void SnowBot_ShouldActivate_WhenTemperatureBelowOrEqualToThreshold()
        {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(b => b.IsEnabled, true)
                                    .With(b => b.Threshold, 0)
                                    .With(b => b.Message, "Brrr, too cold bruh")
                                    .Create();

            var snowBot = new SnowBot(botConfig);

            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(w => w.Temperature, -5)
                                      .Create();

            snowBot.Update(weatherData);
            snowBot.isTriggered.Should().BeTrue();
        }

        [Fact]
        public void SnowBot_ShouldNotActivate_WhenTemperatureAboveToThreshold()
        {
            var botConfig = _fixture.Build<BotConfigDTO>()
                                    .With(b => b.IsEnabled, true)
                                    .With(b => b.Threshold, 0)
                                    .With(b => b.Message, ":machinelearning:")
                                    .Create();
            var snowBot = new SnowBot(botConfig);

            var weatherData = _fixture.Build<WeatherStateDTO>()
                                      .With(w => w.Temperature, 5)
                                      .Create();


            snowBot.Update(weatherData);

            snowBot.isTriggered.Should().BeFalse();
        }
    }
}
