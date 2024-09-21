namespace WeatherApp.Models {
    public class BotConfig {
        public bool IsEnabled { get; set; } = false;

        public double Threshold { get; set; }

        public string? Message { get; set; }
    }
}