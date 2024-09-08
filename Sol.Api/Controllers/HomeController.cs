using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sol.Domain;
using Sol.Domain.Entity;

namespace Sol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
        _logger.LogDebug(1, "NLog injected into HomeController");
    }

    [HttpGet("index")]
    public async Task<IActionResult> Index()
    {
        var result= await _db.Set<AcademicGroup>()
            .Include(x => x.Disciplines)
            .Include(x => x.Students)
            .ToListAsync();
        
        return Ok(result);
    }
}