using System.Text.Json;

//Serializzazione

var weatherForecast = new
{
    Date = DateTime.Parse("2019-08-01"),
    TemperatureCelsius = 25,
    Summary = "Hot"
};

string jsonString = JsonSerializer.Serialize(weatherForecast);

Console.WriteLine(jsonString);

//Deserializzazione

var jsonString = "{\"Date\":\"2019-08-01T00:00:00\",\"TemperatureCelsius\":25,\"Summary\":\"Hot\"}";

var weatherForecast = JsonSerializer.Deserialize<Modello?>(jsonString);

Console.WriteLine(weatherForecast?.TemperatureCelsius);
Console.WriteLine(weatherForecast?.Date);
Console.WriteLine(weatherForecast?.Summary);
