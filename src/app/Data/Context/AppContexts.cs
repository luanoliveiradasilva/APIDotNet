using Data.Mapping;
using Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;
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