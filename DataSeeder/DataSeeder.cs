using Bogus;
using Bogus.DataSets;
using Data;
using Data.Entities;
using Data.Enums;

namespace DataSeeder;

public static class DataSeeder
{
    public static void SeedData(AppDbContext context)
    {
        if (context.Users.Any()) return;

        var faker1 = new Faker<DbSchool>()
            .CustomInstantiator(f => new()
                {
                    Id = f.IndexFaker + 1,
                    Name = $"{f.Name.JobArea()} School"
                });
        var schools = faker1.Generate(2);
        context.Schools.AddRange(schools);

        var faker = new Faker<DbUser>()
            .CustomInstantiator(f =>
            {
                var gender = f.Random.Int(0, 1);
                
                return new()
                    {
                        Id = f.IndexFaker + 1,
                        Gender = (DbUserGender) gender,
                        FirstName = f.Name.FirstName((Name.Gender) gender),
                        LastName = f.Name.LastName((Name.Gender) gender),
                        Email = f.Person.Email
                    };
            })
            .RuleFor(u => u.Post, f => f.Name.JobTitle())
            .RuleFor(u => u.SchoolId, f => f.Random.ArrayElement([(int?) null, 1, 2]))
            .RuleFor(u => u.IsDeleted, f => f.Random.Bool());

        var users = faker.Generate(50);
        context.Users.AddRange(users);
        context.SaveChanges();
    }
}