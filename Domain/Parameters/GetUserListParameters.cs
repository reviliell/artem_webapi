namespace Domain.Parameters;

public class GetUserListParameters
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public bool OnlyUsersWithoutSchool { get; set; }
}