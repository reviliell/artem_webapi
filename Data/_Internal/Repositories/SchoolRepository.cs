using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data._Internal.Repositories;

internal class SchoolRepository(AppDbContext appDbContext) : ISchoolRepository
{
    public async Task<DbSchool?> Find(int id, CancellationToken cancellationToken)
    {
        var school = await appDbContext.Schools.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        return school;
    }
}