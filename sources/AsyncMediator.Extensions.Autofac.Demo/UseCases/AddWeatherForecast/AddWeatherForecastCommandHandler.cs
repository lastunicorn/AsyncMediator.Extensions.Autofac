namespace AsyncMediator.Extensions.Autofac.Demo.UseCases.AddWeatherForecast;

internal class AddWeatherForecastCommandHandler : ICommandHandler<AddWeatherForecastCommand>
{
    public Task<ICommandWorkflowResult> Handle(AddWeatherForecastCommand command)
    {
        Console.WriteLine("Adding a new weather forecast...");

        ICommandWorkflowResult result = CommandWorkflowResult.Ok();
        return Task.FromResult(result);
    }
}