using Microsoft.EntityFrameworkCore;
using src.app.Data.Mapping;
using src.app.Domains.Entities;

namespace src.app.Data.Context
{
    public class AppContexts : DbContext
    {
        public AppContexts(DbContextOptions<AppContexts> options) : base(options) { }


        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMapping().Configure);
        }
    }

}