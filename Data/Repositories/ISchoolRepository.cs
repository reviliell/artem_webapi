using Data.Entities;

namespace Data.Repositories;

public interface ISchoolRepository
{
    Task<DbSchool?> Find(int id, CancellationToken cancellationToken);
}