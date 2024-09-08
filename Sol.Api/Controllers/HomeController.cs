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

    

    [HttpGet("GetDisciplines")]
    public async Task<IActionResult> GetDisciplines()
    {
        var result = await _db.Set<Discipline>()
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpPost("GetDisciplinesBySpeciality")]
    public async Task<IActionResult> GetDisciplinesBySpecialityFilter(bool specialityFilter)
    {
        var result = await _db.Set<Discipline>()
            .Where(x=>x.Specialty == specialityFilter)
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpPost("GetDisciplinesByIsDeleted")]
    public async Task<IActionResult> GetDisciplinesByIsDeletedFilter(bool isDeletedFilter)
    {
        var result = await _db.Set<Discipline>()
            .Where(x=>x.IsDeleted == isDeletedFilter)
            .ToListAsync();
        
        return Ok(result);
    }
}