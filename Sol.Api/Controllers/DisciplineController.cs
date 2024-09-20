using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sol.Domain;
using Sol.Domain.Entity;

namespace Sol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplineController : ControllerBase
{
    private readonly ILogger<DisciplineController> _logger;
    private readonly ApplicationDbContext _db;

    public DisciplineController(ILogger<DisciplineController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }
    
    [HttpGet("GetDisciplines")]
    public async Task<IActionResult> GetDisciplines()
    {
        var result = await _db.Set<Discipline>()
            .Skip(2)
            .Take(1)
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpPost("GetDisciplinesBySpeciality")]
    public async Task<IActionResult> GetDisciplinesBySpecialityFilter(int specialityFilter)
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