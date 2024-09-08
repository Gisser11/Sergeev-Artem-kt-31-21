namespace Sol.Domain.Entity;

public class PerfomanceMark
{
    public int Id { get; set; }

    public int Result { get; set; }

    public Discipline Discipline { get; set; }
    public int DisciplineId { get; set; }

    public Student Student { get; set; }
    public int StudentId { get; set; }
}