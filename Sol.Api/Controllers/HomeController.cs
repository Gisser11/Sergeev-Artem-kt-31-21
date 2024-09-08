using Microsoft.AspNetCore.Mvc;

namespace Sol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into HomeController");
    }

    [HttpGet("index")]
    public IActionResult Index()
    {
        _logger.LogInformation("asdf");
        _logger.LogInformation("2sdfsadf");
        _logger.LogInformation("dfgshfdgh");
        _logger.LogInformation("fdghcvbncvbn");
        _logger.LogInformation("cvbnvchnfdghdf");
        _logger.LogInformation("sdfgsdfgcvbx");
        _logger.LogInformation("dfgshrdfghrseth");
        
        return Ok("hello");
    }
}