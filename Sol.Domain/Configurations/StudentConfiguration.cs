using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;

namespace Sol.Domain.Configurations;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.HasData(new List<Student>
        {
            new Student()
            {
                Id = 1,
                Name = "Iskakov",
                IsDeleted = false,
                AcademicGroupId = 1
            },
            new Student()
            {
                Id = 2,
                Name = "Ivlev",
                IsDeleted = true,
                AcademicGroupId = 1
            },
            new Student()
            {
                Id = 3,
                Name = "Ileeeva",
                IsDeleted = true,
                AcademicGroupId = 1
            },
            new Student()
            {
                Id = 4,
                Name = "Stolov",
                IsDeleted = false,
                AcademicGroupId = 2
            },
            new Student()
            {
                Id = 5,
                Name = "Krovatov",
                IsDeleted = false,
                AcademicGroupId = 2
            },
           
        });

    }
}