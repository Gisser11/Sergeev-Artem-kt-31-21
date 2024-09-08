using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sol.Domain;
using Sol.Domain.Dto;
using Sol.Domain.Entity;

namespace Sol.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public StudentController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentDto student)
    {
        var model = new Student
        {
            Surname = student.Surname,
            Name = student.Name,
            ThirdName = student.ThirdName,
            AcademicGroupId = student.AcademicGroupId
        };
        
        var res = await _db.AddAsync(model);
        await _db.SaveChangesAsync();
        
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
    

    [HttpPost("Edit")]
    public async Task<IActionResult> EditStudent([FromBody] StudentDto student)
    {
        var checkStudent = await _db.Set<Student>()
            .FirstOrDefaultAsync(x => x.Id == student.Id);
        
        if (checkStudent == null)
        {
            return BadRequest("Не найдено! Пользователя не существует");
        }

        checkStudent.Surname = student.Surname;
        checkStudent.Name = student.Name;
        checkStudent.ThirdName = student.ThirdName;
        checkStudent.AcademicGroupId = student.AcademicGroupId;
        
        var res = _db.Update(checkStudent);
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var model = await _db.Set<Student>()
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (model == null)
        {
            return BadRequest("Не найдено! Пользователя не существует");
        }

        _db.Remove(model);
        
        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
}