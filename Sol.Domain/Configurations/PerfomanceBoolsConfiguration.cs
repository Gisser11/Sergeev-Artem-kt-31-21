using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Helpers;

namespace Sol.Domain.Configurations;

public class PerfomanceBoolsConfiguration : IEntityTypeConfiguration<PerformanceBool>
{
    private const string TableName = "cd_perfomance_bools";
    public void Configure(EntityTypeBuilder<PerformanceBool> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName($"pk_{TableName}_perf_bools_id");

        builder.Property(x => x.Id)
            .HasColumnType(ColumnType.Int)
            .HasComment("Первичный ключ")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Result)
            .IsRequired()
            .HasColumnType(ColumnType.Bool)
            .HasColumnName("b_result")
            .HasComment("Первичный ключ");
        
        builder.Property(x => x.DisciplineId)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasComment("вторичный ключ");
        
        builder.Property(x => x.StudentId)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasComment("вторичный ключ");

        builder.HasIndex(x => x.DisciplineId, "fk_discipline_id");
        //builder.Property(x => x.DisciplineId).HasColumnName("Вторичный ключ диспциплины");
        
        builder.HasIndex(x => x.StudentId, "fk_student_id");
        //builder.Property(x => x.DisciplineId).HasColumnName("Вторичный ключ студента");
        
        builder.HasOne(pb => pb.Student)
            .WithMany(s => s.PerformanceBools)
            .HasForeignKey(pb => pb.StudentId)
            .HasConstraintName("fk_student_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Discipline)
            .WithMany(d => d.PerformanceBools)
            .HasForeignKey(p => p.DisciplineId)
            .HasConstraintName("fk_discipline_id")
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