using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Helpers;

namespace Sol.Domain.Configurations;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    //добавить название таблицы как методичке
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Surname)
            .HasColumnName("с_surname")
            .HasColumnType(ColumnType.String)
            .HasComment("Фамилия студента");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("c_name")
            .HasColumnType(ColumnType.String)
            .HasComment("Имя студента");
        
        builder.Property(x => x.ThirdName)
            .HasColumnName("c_thirdname")
            .HasColumnType(ColumnType.String)
            .HasComment("Фамилия студента");
        
        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasColumnName("b_deleted")
            .HasColumnType(ColumnType.Bool)
            .HasComment("существует ли студента");

        
        builder.Property(x => x.AcademicGroupId)
            .HasColumnName("i_academic_group")
            .HasColumnType(ColumnType.Int)
            .HasComment("группа студента");
        
        builder.HasIndex(x => x.AcademicGroupId);//название индекса как в методичке
        
        
        
        builder.HasOne(x => x.AcademicGroup)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.AcademicGroupId)
            //.HasConstarainName
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