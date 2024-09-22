using Application.Services;
using Data.Repositories;
using Domain.Models;

namespace Application._Internal.Services;

internal class SchoolService(ISchoolRepository schoolRepository) : ISchoolService
{
    public async Task<School?> Find(int id, CancellationToken cancellationToken)
    {
        var dbSchool = await schoolRepository.Find(id, cancellationToken);
        
        var school = dbSchool == default 
            ? default 
            : new School {Id = dbSchool.Id, Name = dbSchool.Name};
        
        return school;
    }
}