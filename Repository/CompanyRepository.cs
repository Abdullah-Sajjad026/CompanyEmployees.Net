using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }
}