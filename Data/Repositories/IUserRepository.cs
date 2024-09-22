using Data.Entities;
using Domain.Parameters;

namespace Data.Repositories;

public interface IUserRepository
{
    Task<DbUser?> Find(int id, CancellationToken cancellationToken = default);
    
    Task<DbUser> Get(int id, CancellationToken cancellationToken = default);
    
    Task<(DbUser[] Items, int TotalCount)> GetList(
        GetUserListParameters @params,
        CancellationToken cancellationToken = default);
    
    Task SetSchoolId(int userId, int schoolId, CancellationToken cancellationToken = default);
}