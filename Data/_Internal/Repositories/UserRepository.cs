using Data.Entities;
using Data.Repositories;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Data._Internal.Repositories;

internal class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    public async Task<DbUser?> Find(int id, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users.FirstOrDefaultAsync(
            u => u.Id == id && u.IsDeleted == false,
            cancellationToken);
        return user;
    }
    
    public async Task<DbUser> Get(int id, CancellationToken cancellationToken)
    {
        var user = await Find(id, cancellationToken);
        if (user == default)
        {
            throw new($"Пользователь с идентификатором '{id}' не найден");
        }
        
        return user;
    }
    
    public async Task<(DbUser[] Items, int TotalCount)> GetList(
        GetUserListParameters @params,
        CancellationToken cancellationToken)
    {
        var query = appDbContext.Users
            .Where(u => u.IsDeleted == false);

        if (@params.OnlyUsersWithoutSchool)
        {
            query = query.Where(u => u.SchoolId == null);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        
        var countToSkip = (@params.PageNumber - 1) * @params.PageSize;
        var users = await query
            .OrderBy(u => u.Id)
            .Skip(countToSkip)
            .Take(@params.PageSize)
            .ToArrayAsync(cancellationToken);
        
        return (Items: users, TotalCount: totalCount);
    }

    public async Task SetSchoolId(int userId, int schoolId, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users.FirstOrDefaultAsync(
            u => u.Id == userId && u.IsDeleted == false,
            cancellationToken);
        if (user == default)
        {
            return;
        }
        
        user.SchoolId = schoolId;
        
        appDbContext.Users.Update(user);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}