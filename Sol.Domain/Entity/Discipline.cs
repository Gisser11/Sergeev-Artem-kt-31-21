using System.Text.Json.Serialization;

namespace Sol.Domain.Entity;

public class Discipline
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public int Specialty { get; set; }

    public bool IsDeleted { get; set; }

    [JsonIgnore]
    public ICollection<AcademicGroup> AcademicGroups { get; set; }

    [JsonIgnore] 
    public ICollection<PerformanceBool> PerformanceBools { get; set; }
}

