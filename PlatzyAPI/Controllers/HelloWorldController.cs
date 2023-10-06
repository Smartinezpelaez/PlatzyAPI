using Microsoft.AspNetCore.Mvc;
using PlatzyAPI.Services;

namespace PlatzyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    private readonly IHelloWorldServices helloWorldServices;
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldServices helloWorldServices, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        this.helloWorldServices = helloWorldServices;     
    }

    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        _logger.LogDebug ("Obtenemos Hola Mundo");
        return Ok(helloWorldServices.GetHelloWorld());
    }

}
