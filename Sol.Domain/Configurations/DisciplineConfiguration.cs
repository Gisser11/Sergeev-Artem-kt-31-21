using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity;
using Sol.Domain.Helpers;

namespace Sol.Domain.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    private const string TableName = "cd_discipline";
    
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName($"pk_{TableName}_discipline_id");
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("c_name")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Имя студента");
        
        builder.Property(x => x.Specialty)
            .IsRequired()
            .HasColumnName("i_speciality")
            .HasColumnType(ColumnType.Int)
            .HasComment("Специальность студента");
        
        builder.Property(x => x.IsDeleted)
            .HasColumnName("b_deleted")
            .IsRequired()
            .HasColumnType(ColumnType.Bool)
            .HasComment("Существует ли студент");
        
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