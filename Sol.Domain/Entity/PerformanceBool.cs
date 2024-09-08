namespace Sol.Domain.Entity;

public class PerformanceBool
{
    public int Id { get; set; }

    public bool Result { get; set; }

    public Discipline Discipline { get; set; }
    public int DisciplineId { get; set; }

    public Student Student { get; set; }
    public int StudentId { get; set; }

}