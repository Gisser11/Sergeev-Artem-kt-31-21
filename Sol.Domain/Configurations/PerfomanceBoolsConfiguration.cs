using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;

namespace Sol.Domain.Configurations;

public class PerfomanceBoolsConfiguration : IEntityTypeConfiguration<PerformanceBool>
{
    public void Configure(EntityTypeBuilder<PerformanceBool> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Result)
            .HasColumnName("result");

        builder.HasIndex(x => x.DisciplineId);
        builder.HasIndex(x => x.StudentId);
        
        builder.HasOne(pb => pb.Student)
            .WithMany(s => s.PerformanceBools)
            .HasForeignKey(pb => pb.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Discipline)
            .WithMany(d => d.PerformanceBools)
            .HasForeignKey(p => p.DisciplineId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        
        builder.HasData(new List<PerformanceBool>
        {   
            new PerformanceBool()
            {
                Id = 1,
                DisciplineId = 1,
                StudentId = 1,
                Result = true
            },
            new PerformanceBool()
            {
                Id = 2,
                DisciplineId = 2,
                StudentId = 1,
                Result = false
            },
            new PerformanceBool()
            {
                Id = 3,
                DisciplineId = 3,
                StudentId = 1,
                Result = true
            },
            new PerformanceBool()
            {
                Id = 4,
                DisciplineId = 3,
                StudentId = 2,
                Result = true
            },
            new PerformanceBool()
            {
                Id = 5,
                DisciplineId = 3,
                StudentId = 3,
                Result = true
            },
            new PerformanceBool()
            {
                Id = 6,
                DisciplineId = 3,
                StudentId = 4,
                Result = true
            },
            new PerformanceBool()
            {
                Id = 7,
                DisciplineId = 1,
                StudentId = 4,
                Result = false
            },
        });
    }
}