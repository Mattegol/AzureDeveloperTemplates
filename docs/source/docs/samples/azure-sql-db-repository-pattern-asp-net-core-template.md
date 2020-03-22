[Azure SQL DB Repository Pattern with Entity Framework Core and ASP .NET Core Template](https://github.com/Daniel-Krzyczkowski/AzureDeveloperTemplates/tree/master/src/azure-sql-db-repository-pattern-asp-net-core-template)

Sample project to present how to use repository pattern with Azure SQL DB.

```csharp
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                                                                        : base(options)
        {
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SampleEntity>().HasData(new SampleEntity
            {
                Id = Guid.NewGuid()
            });
        }
    }
```
```