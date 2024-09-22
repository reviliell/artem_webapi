using Domain.Models;

namespace Application.Services;

public interface ISchoolService
{
    Task<School?> Find(int id, CancellationToken cancellationToken);
}