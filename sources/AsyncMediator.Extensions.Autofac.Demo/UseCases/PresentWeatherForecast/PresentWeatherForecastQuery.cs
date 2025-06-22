namespace AsyncMediator.Extensions.Autofac.Demo.UseCases.PresentWeatherForecast;

internal class PresentWeatherForecastQuery : IQuery<PresentWeatherForecastCriteria, PresentWeatherForecastResponse>
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public Task<PresentWeatherForecastResponse> Query(PresentWeatherForecastCriteria criteria)
    {
        IEnumerable<WeatherForecast> weatherForecasts = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        return Task.FromResult(new PresentWeatherForecastResponse
        {
            WeatherForecasts = weatherForecasts
        });
    }
}