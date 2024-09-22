using Data._Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configs;

internal class DbUserConfig : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder
            .ToTable("User")
            .HasKey(u => u.Id);

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(Constants.MaxStringLength)
            .IsRequired();
        
        builder
            .Property(u => u.LastName)
            .HasMaxLength(Constants.MaxStringLength)
            .IsRequired();
        
        builder
            .Property(u => u.Email)
            .HasMaxLength(Constants.MaxStringLength)
            .IsRequired();
    }
}