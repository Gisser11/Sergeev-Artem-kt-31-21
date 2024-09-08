using System.Text.Json.Serialization;

namespace Sol.Domain.Entity;

public class PerfomanceMark
{
    public int Id { get; set; }

    public int Result { get; set; }

    [JsonIgnore]
    public Discipline Discipline { get; set; }
    public int DisciplineId { get; set; }
    
    [JsonIgnore]
    public Student Student { get; set; }
    public int StudentId { get; set; }
}