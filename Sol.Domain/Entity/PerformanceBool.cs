using System.Text.Json.Serialization;

namespace Sol.Domain.Entity;

public class PerformanceBool
{
    public int Id { get; set; }

    public bool Result { get; set; }
    
    [JsonIgnore]
    public Discipline Discipline { get; set; }
    public int DisciplineId { get; set; }
    
    [JsonIgnore]
    public Student Student { get; set; }
    public int StudentId { get; set; }
}