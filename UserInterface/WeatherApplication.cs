using WeatherApp.InputDataParser.Strategies;
using WeatherApp.Models;
using WeatherApp.Strategies;

namespace WeatherApp.UserInterface {
    public class WeatherApplication {
        public void StartApplication() {
            while(true) {
                repeatChoice:
                    Console.WriteLine("Weather Monitoring and Reporting Service");
                    Console.WriteLine("Enter Weather Sate using one of the following formates:");
                    Console.WriteLine("1. JSON Format");
                    Console.WriteLine("2. XML Format \n");
                    Console.WriteLine("Choose an option: ");

                    var choice = Console.ReadLine();

                    var inputProcessStrategy = new WeatherStrategyContext();
                    switch(choice) 
                    {
                        case "1": 
                        {
                            repeatCase1:
                                inputProcessStrategy.SetProcessingStrategy(new JSONDataParser());
                                string? userWeatherInput = ReadInputFromUser(inputProcessStrategy);
                                try {
                                    var weatherData = inputProcessStrategy.WeatherDeserialize(userWeatherInput);
                                } catch (Exception ex) {
                                    Console.WriteLine($"Invalid Input format. {ex.Message}");
                                    goto repeatCase1;
                                }
                                break;
                        }
                        case "2": 
                        {
                            repeatCase2:
                                inputProcessStrategy.SetProcessingStrategy(new XMLDataParser());
                                string? userWeatherInput = ReadInputFromUser(inputProcessStrategy);
                                try {
                                    var weatherData = inputProcessStrategy.WeatherDeserialize(userWeatherInput);
                                } catch(Exception ex) {
                                    Console.WriteLine($"Invalid input format. {ex.Message}");
                                    goto repeatCase2;
                                }
                                break;
                        }

                        default: {
                            Console.WriteLine("Invalid input.");
                            goto repeatChoice;
                        }
                }
            }
        }
        public string? ReadInputFromUser(WeatherStrategyContext strategy) 
        {
            repeat:
                Console.WriteLine("Enter the Weather data in the appropriate form.");
                var weatherStateInput = Console.ReadLine();
                bool isNotValidInput = string.IsNullOrWhiteSpace(weatherStateInput) ||  
                                        !strategy.CanParse(weatherStateInput);
                while(isNotValidInput) {
                    Console.WriteLine("Invalid form of input.");
                    goto repeat;
                }
            return weatherStateInput;
        }
    }
}