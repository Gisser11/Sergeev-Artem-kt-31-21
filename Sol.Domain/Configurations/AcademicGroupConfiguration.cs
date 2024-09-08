using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Entity.ManyToMany;

namespace Sol.Domain.Configurations;

public class AcademicGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
{
    public void Configure(EntityTypeBuilder<AcademicGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasMany(x => x.Students)
            .WithOne(x => x.AcademicGroup)
            .HasForeignKey(x => x.AcademicGroupId)
            .OnDelete(DeleteBehavior.Cascade);

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
        
        builder.HasMany(ag => ag.Students)
            .WithOne(s => s.AcademicGroup)
            .HasForeignKey(s => s.AcademicGroupId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasData(new List<AcademicGroup>
        {
            new AcademicGroup()
            {
                Id = 1,
                Name = "kt-41-21",
                Specialty = false,
                Year = 2021
            },
            new AcademicGroup()
            {
                Id = 2,
                Name = "kt-51-21",
                Specialty = true,
                Year = 2021
            }
            ,
            new AcademicGroup()
            {
                Id = 3,
                Name = "kt-55-21",
                Specialty = true,
                Year = 2021
            }
            ,
            new AcademicGroup()
            {
                Id = 4,
                Name = "kt-41-22",
                Specialty = false,
                Year = 2022
            },
            new AcademicGroup()
            {
                Id = 5,
                Name = "kt-41-22",
                Specialty = true,
                Year = 2022
            }
        });
    }
}