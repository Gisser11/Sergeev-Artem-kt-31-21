namespace Sol.Domain.Entity;

public class Discipline
{
    public int Id { get; set; }

    public string Name { get; set; }

    // true - гумм. false - техн.
    public bool Specialty { get; set; }

    public bool IsDeleted { get; set; }


    public ICollection<AcademicGroup> AcademicGroups { get; set; }
}

