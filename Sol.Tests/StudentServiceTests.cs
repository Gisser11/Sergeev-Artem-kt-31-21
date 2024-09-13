using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Sol.Api.Services;
using Sol.Domain;
using Sol.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;
using Sol.Api.Services.Students;
using Xunit;

namespace Sol.Tests
{
    public class StudentServiceTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Mock<ILogger<StudentService>> _logger;
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            // Initialize the in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _logger = new Mock<ILogger<StudentService>>();
            _studentService = new StudentService(_dbContext, _logger.Object);
        }

        [Fact]
        public async Task DeleteUser_ShouldReturnTrue_WhenStudentExists()
        {
            // Arrange
            var studentId = 1;
            var student = new Student { Id = studentId, Name = "gisser"};
            _dbContext.Add(student);
            await _dbContext.SaveChangesAsync();

            // Act
            await _studentService.DeleteUser(studentId);

            // Assert
            Assert.Null(await _dbContext.Set<Student>().FirstOrDefaultAsync(x=>x.Id == studentId)); 
        }
    }
}