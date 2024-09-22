namespace Data.Entities;

public class DbSchool
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool IsDeleted { get; set; }
    
    public ICollection<DbUser> Users { get; set; }
}