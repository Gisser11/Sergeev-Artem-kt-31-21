using Microsoft.EntityFrameworkCore;
using Sol.Domain;
using Sol.Domain.Dto;
using Sol.Domain.Entity;

namespace Sol.Api.Services.Students;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<StudentService> _logger;

    public StudentService(ApplicationDbContext db, ILogger<StudentService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task CreateUser(StudentDto student)
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
    }

    public async Task EditUser(StudentDto student)
    {
        var checkStudent = await _db.Set<Student>()
            .FirstOrDefaultAsync(x => x.Id == student.Id);
        
        if (checkStudent == null)
        {
            throw new Exception();
        }

        checkStudent.Surname = student.Surname;
        checkStudent.Name = student.Name;
        checkStudent.ThirdName = student.ThirdName;
        checkStudent.AcademicGroupId = student.AcademicGroupId;
        
        var res = _db.Update(checkStudent);
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var model = await _db.Set<Student>()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (model == null)
        {
            throw new Exception();
        }

        _db.Remove(model);
        throw new Exception();
        await _db.SaveChangesAsync();


    }
}