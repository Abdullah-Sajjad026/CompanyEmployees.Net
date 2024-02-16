
using CompanyEmployees.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyEmployees.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<RepositoryContext>()
        .UseSqlite(configuration.GetConnectionString("SQLiteConnection"),
                    b => b.MigrationsAssembly("CompanyEmployees")
        );

        return new RepositoryContext(dbContextOptionsBuilder.Options);
    }
}