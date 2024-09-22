using Domain.Models;
using Domain.Parameters;

namespace Application.Services;

public interface IUserService
{
    Task<User?> Find(int id, CancellationToken cancellationToken = default);
    
    Task<User> Get(int id, CancellationToken cancellationToken = default);
    
    Task<(User[] Items, int TotalCount)> GetList(
        GetUserListParameters @params,
        CancellationToken cancellationToken = default);
    
    Task SetSchoolId(int userId, int schoolId, CancellationToken cancellationToken = default);
}