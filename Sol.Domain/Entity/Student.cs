using System.Text.Json.Serialization;

namespace Sol.Domain.Entity;

public class Student
{
    public int Id { get; set; }
    
    public string Surname { get; set; } = "";

    public string Name { get; set; } = "";
    
    public string ThirdName { get; set; } = "";

    public bool IsDeleted { get; set; }

    [JsonIgnore]
    public AcademicGroup AcademicGroup { get; set; }
    public int AcademicGroupId { get; set; }

    public ICollection<PerformanceBool> PerformanceBools { get; set; }
    
    public ICollection<PerfomanceMark> PerfomanceMarks { get; set; }

}