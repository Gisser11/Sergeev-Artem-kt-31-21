using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;

namespace Sol.Domain.Configurations;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Surname)
            .HasColumnName("surname")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.ThirdName)
            .HasColumnName("thirdName")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.IsDeleted)
            .HasColumnName("isDeleted")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.AcademicGroupId)
            .HasColumnName("academicGroupId")
            .ValueGeneratedOnAdd();
        
        builder.HasIndex(x => x.AcademicGroupId);
        
        
        
        builder.HasOne(x => x.AcademicGroup)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.AcademicGroupId)
            .OnDelete(DeleteBehavior.Cascade);
        
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