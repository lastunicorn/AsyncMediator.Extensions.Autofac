namespace AsyncMediator.Extensions.Autofac.Demo.UseCases.PresentWeatherForecast;

public class PresentWeatherForecastResponse
{
    public IEnumerable<WeatherForecast> WeatherForecasts { get; internal set; }
}