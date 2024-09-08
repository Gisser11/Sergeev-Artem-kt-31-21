using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;

namespace Sol.Domain.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasData(new List<Discipline>
        {
            new Discipline()
            {
                Id = 1,
                IsDeleted = false,
                Specialty = true,
                Name = "Матеша1",
            },
            new Discipline()
            {
                Id = 2,
                IsDeleted = false,
                Specialty = true,
                Name = "Матеша2",
            },
            new Discipline()
            {
                Id = 3,
                IsDeleted = false,
                Specialty = true,
                Name = "Матеша3",
            },
        });
    }
}