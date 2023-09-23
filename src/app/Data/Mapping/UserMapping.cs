using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>

{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.Email).IsUnique();

        builder.Property(user => user.Name).IsRequired().HasMaxLength(60);

        builder.Property(user => user.Email).HasMaxLength(100);
    }
}