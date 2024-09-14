using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;

namespace Sol.Domain.Configurations;

public class PerfomanceMarksConfiguration : IEntityTypeConfiguration<PerfomanceMark>
{
    public void Configure(EntityTypeBuilder<PerfomanceMark> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Result)
            .HasColumnName("result");
        
        builder.HasIndex(x => x.DisciplineId);
        builder.HasIndex(x => x.StudentId);
        
        builder.HasOne(pb => pb.Student)
            .WithMany(s => s.PerfomanceMarks)
            .HasForeignKey(pb => pb.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}