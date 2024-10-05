[![Build and Test](https://github.com/v1rushb/Weather-Application/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/v1rushb/Weather-Application/actions/workflows/build-and-test.yml)

## **General Task Description:**

Design and implement a C# console application that simulates a real-time weather monitoring and reporting service. The system should be capable of receiving and processing raw weather data in multiple formats (JSON, XML, etc.) from various weather stations for different locations. The application should include different types of 'weather bots' each of which is configured to behave differently based on the weather updates it receives.

## **Supported Input Formats:**

### **JSON Format**:

```json

{
  "Location": "City Name",
  "Temperature": 23.0,
  "Humidity": 85.0
}
```

### **XML Format**:

```xml
<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>
```

The system should allow for the addition of new data formats with minimal changes to the existing code, demonstrating the Open-Closed principle of SOLID design principles.

## **Different Bot Types:**

1. **RainBot**: This bot gets activated when the humidity level exceeds a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.
2. **SunBot**: This bot gets activated when the temperature rises above a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.
3. **SnowBot**: This bot is activated when the temperature drops below a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.

## **Example on How to Interact with the Application:**

User starts the application, the system prompts: **`Enter weather data:`**.

User enters data in JSON format: **`{"Location": "City Name", "Temperature": 32, "Humidity": 40}`** or XML format: **`<WeatherStateDTO><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherStateDTO>`**

The system responds by activating the bots according to the provided weather data and the bots' configurations. If SunBot is enabled and its temperature threshold is lower than the given temperature, the system may respond with:

```vbnet
SunBot activated!
SunBot: "Wow, it's a scorcher out there!"
```

### **Configuration Details:**

All the bot's settings should be controlled via a configuration file, including whether it is enabled, the threshold that activates it, and the message it outputs when activated. The configuration file should be in a JSON format. Here is an example:

```json
{
    "RainBot": {
        "Enabled": true,
        "HumidityThreshold": 70,
        "Message": "It looks like it's about to pour down!"
    },
    "SunBot": {
        "Enabled": true,
        "TemperatureAboveThreshold": 30,
        "Message": "Wow, it's a scorcher out there!"
    },
    "SnowBot": {
        "Enabled": false,
        "TemperatureUnderThreshold": 0,
        "Message": "Brrr, it's getting chilly!"
    }
}
```

In this example, the **`enabled`** property turns the bot on or off, the **`humidityThreshold`** or **`temperatureThreshold`** sets the limit that will activate the bot, and **`message`** is what the bot will output when it is activated.

In this task I applied these design patterns:
Singleton: to get the configurations from the file.
Strategy: to choose the input method (JSON or XML).
Observer: to notify the bots about the current weather state and act accordingly.

**Extensibility:**</br>
Bots can be added and removed simply via the configurations file.</br>
Input formats can be added by implementing IWeatherInputStrategy.
