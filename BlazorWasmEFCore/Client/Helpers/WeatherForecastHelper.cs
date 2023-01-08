using BlazorWasmEFCore.Shared;

namespace BlazorWasmEFCore.Client.Helpers
{
    public static class WeatherForecastHelper
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static IEnumerable<WeatherForecast> GetWeatherForecasts(int length = 5)
        {
            return Enumerable.Range(1, length).Select(index => {
                var temperatureC = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    TemperatureF = 32 + (int)(temperatureC / 0.5556),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            });
        }

        public static IEnumerable<WeatherForecast> WithId(this IEnumerable<WeatherForecast> weatherForecasts)
        {
            return weatherForecasts.Select((x, i) =>
            {
                x.Id = i + 1;
                return x;
            });
        }
    }
}
