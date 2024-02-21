
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Repository;

public class RepositoryContext : DbContext
{

    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    public DbSet<Company>? Companies { get; set; }
    public DbSet<Employee>? Employees { get; set; }
}