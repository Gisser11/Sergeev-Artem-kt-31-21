using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Helpers;

namespace Sol.Domain.Configurations;

public class PerfomanceMarksConfiguration : IEntityTypeConfiguration<PerfomanceMark>
{
    private const string TableName = "cd_perfomance_marks";
    public void Configure(EntityTypeBuilder<PerfomanceMark> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName($"cd_{TableName}_perf_marks_id");
        
        builder.Property(x => x.Result)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasColumnName("b_result")
            .HasComment("Первичный ключ");
        
        builder.Property(x => x.DisciplineId)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasColumnName($"fk_{TableName}_discipline_id")
            .HasComment("вторичный ключ");
        
        builder.Property(x => x.StudentId)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasColumnName($"fk_{TableName}_student_id")
            .HasComment("вторичный ключ");
        
        
        builder.HasIndex(x => x.DisciplineId);
        builder.HasIndex(x => x.StudentId);
        
        builder.HasOne(pb => pb.Student)
            .WithMany(s => s.PerfomanceMarks)
            .HasForeignKey(pb => pb.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}