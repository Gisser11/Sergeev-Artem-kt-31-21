using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sol.Api.Services;
using Sol.Domain;
using Sol.Domain.Dto;
using Sol.Domain.Entity;

namespace Sol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IStudentService _studentService;
    public StudentController(ApplicationDbContext db, IStudentService studentService)
    {
        _db = db;
        _studentService = studentService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentDto student)
    {
        var res = await _studentService.CreateUser(student);
        
        return Ok(res);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> EditStudent([FromBody] StudentDto student)
    {
        var res = await _studentService.EditUser(student);
        
        return Ok(res);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var res = await _studentService.DeleteUser(id);
        
        return Ok();
    }
    
    [HttpPost("GetCurrentStudent")]
    public async Task<IActionResult> GetCurrentStudent(int id)
    {
        var model = await _db.Set<Student>()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (model == null)
        {
            return BadRequest("Не найдено! Пользователя не существует");
        }
        return Ok(model);
    }
}