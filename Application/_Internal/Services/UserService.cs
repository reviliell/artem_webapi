using Application.Services;
using Data.Repositories;
using Domain.Enums;
using Domain.Models;
using Domain.Parameters;

namespace Application._Internal.Services;

internal class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> Find(int id, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.Find(id, cancellationToken);
        
        var user = dbUser == default
            ? default
            : new User
                {
                    Id = dbUser.Id,
                    Gender = (UserGender) dbUser.Gender,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email,
                    Post = dbUser.Post,
                    SchoolId = dbUser.SchoolId
                };
        return user;
    }

    public async Task<User> Get(int id, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.Get(id, cancellationToken);
        
        var user = new User
        {
            Id = dbUser.Id,
            Gender = (UserGender) dbUser.Gender,
            FirstName = dbUser.FirstName,
            LastName = dbUser.LastName,
            Email = dbUser.Email,
            Post = dbUser.Post,
            SchoolId = dbUser.SchoolId
        };
        return user;
    }
    
    public async Task<(User[] Items, int TotalCount)> GetList(
        GetUserListParameters @params,
        CancellationToken cancellationToken)
    {
        var getListResult = await userRepository.GetList(@params, cancellationToken);
        
        var users = getListResult.Items
            .Select(u => new User
                {
                    Id = u.Id,
                    Gender = (UserGender) u.Gender,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Post = u.Post,
                    SchoolId = u.SchoolId
                })
            .ToArray();
        
        return (Items: users, getListResult.TotalCount);
    }

    public async Task SetSchoolId(int userId, int schoolId, CancellationToken cancellationToken)
    {
        await userRepository.SetSchoolId(userId, schoolId, cancellationToken);
    }
}