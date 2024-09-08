using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Domain.Entity.ManyToMany;

namespace Sol.Domain.Configurations;

public class GroupDisciplineConfiguration : IEntityTypeConfiguration<AcademicGroupAndDisciplines>
{
    public void Configure(EntityTypeBuilder<AcademicGroupAndDisciplines> builder)
    {
        builder.HasData(new List<AcademicGroupAndDisciplines>
        {
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 1,
                DisciplineId = 1
            },
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 1,
                DisciplineId = 2
            },
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 2,
                DisciplineId = 3
            },
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 2,
                DisciplineId = 1
            },
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 3,
                DisciplineId = 1
            },
            new AcademicGroupAndDisciplines()
            {
                AcademicGroupId = 3,
                DisciplineId = 2
            },
        });
    }
}