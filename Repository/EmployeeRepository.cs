using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }
}