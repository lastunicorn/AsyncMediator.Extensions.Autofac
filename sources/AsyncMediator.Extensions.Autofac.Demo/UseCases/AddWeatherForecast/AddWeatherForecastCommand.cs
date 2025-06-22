namespace AsyncMediator.Extensions.Autofac.Demo.UseCases.AddWeatherForecast;

public class AddWeatherForecastCommand : ICommand
{
    public WeatherForecast WeatherForecast { get; internal set; }
}