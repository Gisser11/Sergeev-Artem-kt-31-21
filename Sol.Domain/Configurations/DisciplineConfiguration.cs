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
        
        builder.HasMany(s => s.PerformanceBools)
            .WithOne(p => p.Discipline)
            .HasForeignKey(p => p.DisciplineId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<Discipline>
        {
            new Discipline()
            {
                Id = 1,
                IsDeleted = false,
                Specialty = 1,
                Name = "Матеша1",
            },
            new Discipline()
            {
                Id = 2,
                IsDeleted = false,
                Specialty = 2,
                Name = "Матеша2",
            },
            new Discipline()
            {
                Id = 3,
                IsDeleted = false,
                Specialty = 3,
                Name = "Матеша3",
            },
        });
    }
}