using AsyncMediator.Extensions.Autofac.Demo.UseCases.AddWeatherForecast;
using AsyncMediator.Extensions.Autofac.Demo.UseCases.PresentWeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace AsyncMediator.Extensions.Autofac.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator mediator;

    public WeatherForecastController(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        PresentWeatherForecastCriteria criteria = new();
        PresentWeatherForecastResponse response = await mediator.Query<PresentWeatherForecastCriteria, PresentWeatherForecastResponse>(criteria);

        return response.WeatherForecasts;
    }

    [HttpPost(Name = "AddWeatherForecast")]
    public async Task<IActionResult> Post([FromBody] WeatherForecast weatherForecast)
    {
        AddWeatherForecastCommand command = new()
        {
            WeatherForecast = weatherForecast
        };
        ICommandWorkflowResult result = await mediator.Send(command);

        return result.Success
            ? Ok()
            : StatusCode(StatusCodes.Status500InternalServerError, "An internal error occurred.");
    }
}