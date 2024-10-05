namespace WeatherApp.Models {
    public class BotConfigDTO {
        public bool IsEnabled { get; set; } = false;

        public double Threshold { get; set; }

        public string? Message { get; set; }
    }
}