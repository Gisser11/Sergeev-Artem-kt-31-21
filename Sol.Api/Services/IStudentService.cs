using Sol.Domain.Dto;

namespace Sol.Api.Services;

public interface IStudentService
{
    public Task<bool> CreateUser(StudentDto student);
    
    public Task<bool> EditUser(StudentDto student);
    
    public Task<bool> DeleteUser(int id);
}