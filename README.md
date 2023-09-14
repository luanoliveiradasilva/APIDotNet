# APIDotNet


**Create new project in .netcore with command cli:**

> ```dotnet new webapi --name --framework net6```
 
This is reference: [dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

**Install [nugets](https://www.nuget.org/):**
**Example:**
> ```<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.11" />```

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Pomelo.EntityFrameworkCore

**Create migration**
This is reference: [Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

To create the migration, it is necessary to create the entity classes, create the connection to the database and execute the commands as per the reference.

Add the database connection in appsetting.

> "ConnectionStrings": {
      "AppContexts": "server=localhost;userid=userid;password=pwd;Port=3306; database=database"
  }


And in the program add AddDbContext to connect the entity and so that it is possible to add the data to the migration.

>  builder.Services.AddDbContext<AppContexts>(options => options.UseMySql(builder.Configuration.GetConnectionString("AppContexts"), ServerVersion.Parse("7.0.0") ?? throw new InvalidOperationException("Connection string 'AppContext' not found.")));



You also need to create the Context class to add the entity class data.

```C#
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
```

Now, just execute the necessary commands according to the reference.

```dotnet ef migrations add InitialCreate```
```dotnet ef database update```