using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.app.Domains.Entities;

namespace src.app.Data.Mapping
{
    public class UserMapping/* : IEntityTypeConfiguration<User> */

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");
        }
    }
}