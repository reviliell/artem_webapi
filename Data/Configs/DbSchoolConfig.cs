using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configs;

internal class DbSchoolConfig : IEntityTypeConfiguration<DbSchool>
{
    public void Configure(EntityTypeBuilder<DbSchool> builder)
    {
        builder
            .ToTable("School")
            .HasKey(s => s.Id);

        builder
            .HasMany(s => s.Users)
            .WithOne(u => u.School)
            .HasForeignKey(u => u.SchoolId);
    }
}