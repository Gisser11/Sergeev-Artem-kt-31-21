using Microsoft.EntityFrameworkCore;
using Sol.Domain;
using Sol.Domain.Dto;
using Sol.Domain.Entity;

namespace Sol.Api.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<StudentService> _logger;

    public StudentService(ApplicationDbContext db, ILogger<StudentService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<bool> CreateUser(StudentDto student)
    {
        try
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

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "");
            return false;
        }
    }

    public async Task<bool> EditUser(StudentDto student)
    {
        try
        {
            var checkStudent = await _db.Set<Student>()
                .FirstOrDefaultAsync(x => x.Id == student.Id);
        
            if (checkStudent == null)
            {
                return false;
            }

            checkStudent.Surname = student.Surname;
            checkStudent.Name = student.Name;
            checkStudent.ThirdName = student.ThirdName;
            checkStudent.AcademicGroupId = student.AcademicGroupId;
        
            var res = _db.Update(checkStudent);
        
            await _db.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "");
            return false;
        }
    }

    public async Task<bool> DeleteUser(int id)
    {
        try
        {
            var model = await _db.Set<Student>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return false;
            }

            _db.Remove(model);

            await _db.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "");
            return false;
        }
    }
}