using Microsoft.AspNetCore.Mvc;

namespace PlatzyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherforecasts = new List<WeatherForecast>();


    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherforecasts == null || !ListWeatherforecasts.Any())
        {
            ListWeatherforecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Retorna Lista de WeatherForecast");
        return ListWeatherforecasts;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherforecasts.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete ("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherforecasts.RemoveAt(index);
        return Ok();
    }

}