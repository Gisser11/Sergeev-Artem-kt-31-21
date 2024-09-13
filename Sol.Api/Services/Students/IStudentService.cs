using Sol.Domain.Dto;

namespace Sol.Api.Services.Students;

public interface IStudentService
{
    public Task CreateUser(StudentDto student);
    
    public Task EditUser(StudentDto student);
    
    public Task DeleteUser(int id);
}