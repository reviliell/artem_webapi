using Data.Enums;

namespace Data.Entities;

public class DbUser
{
    public required int Id { get; set; }
    public required DbUserGender Gender { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Post { get; set; }
    public int? SchoolId { get; set; }
    public bool IsDeleted { get; set; }

    public DbSchool? School { get; set; }
}