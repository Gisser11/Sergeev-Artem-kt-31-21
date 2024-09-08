namespace Sol.Domain.Entity;

public class AcademicGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    // true - гумм. false - техн.
    public bool Specialty { get; set; }
    
    public ushort Year { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }
    public ICollection<Student> Students { get; set; }
}