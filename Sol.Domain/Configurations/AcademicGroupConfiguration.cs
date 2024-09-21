using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Entity.ManyToMany;
using Sol.Domain.Helpers;

namespace Sol.Domain.Configurations;

public class AcademicGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
{
    private const string TableName = "cd_AcademicGroup";
    
    public void Configure(EntityTypeBuilder<AcademicGroup> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName($"pk_{TableName}_academic_group_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("c_name")
            .HasColumnType(ColumnType.String)
            .HasComment("Имя студента");
        
        builder.Property(x => x.Specialty)
            .IsRequired()
            .HasColumnName("n_specialty");
        
        builder.Property(x => x.Year)
            .IsRequired()
            .HasColumnName("n_year");
        
        builder.HasMany(x => x.Disciplines)
            .WithMany(x => x.AcademicGroups)
            .UsingEntity<AcademicGroupAndDisciplines>(
                x => x.HasOne<Discipline>()
                    .WithMany()
                    .HasForeignKey(left => left.DisciplineId),
                x => x.HasOne<AcademicGroup>()
                    .WithMany()
                    .HasForeignKey(right => right.AcademicGroupId)
            );
        
        
        builder.HasData(new List<AcademicGroup>
        {
            new AcademicGroup()
            {
                Id = 1,
                Name = "kt-41-21",
                Specialty = 1,
                Year = 2021
            },
            new AcademicGroup()
            {
                Id = 2,
                Name = "kt-51-21",
                Specialty = 1,
                Year = 2021
            }
            ,
            new AcademicGroup()
            {
                Id = 3,
                Name = "kt-55-21",
                Specialty = 2,
                Year = 2021
            }
            ,
            new AcademicGroup()
            {
                Id = 4,
                Name = "kt-41-22",
                Specialty = 2,
                Year = 2022
            },
            new AcademicGroup()
            {
                Id = 5,
                Name = "kt-41-22",
                Specialty = 1,
                Year = 2022
            }
        });
    }
}