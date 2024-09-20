using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models {
    public class WeatherStateDTO {

        [Required]
        public string Location { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        public double Humidity { get; set; }


        public override string ToString() => $"Location: {Location}\n" + 
                                              $"Temperature: {Temperature}\n" +
                                              $"Humdidity: {Humidity}";
    }
}