using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Contracts;
using CompanyEmployees.Shared.DTOs;

namespace CompanyEmployees.Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public CompanyService(
        IRepositoryManager repositoryManager,
        ILoggerManager loggerManager
    )
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

            var companiesDtos = companies.Select(c =>
                new CompanyDto(c.Id, c.Name ?? "", string.Join(" ", c.Address, c.Country))
            ).ToList();

            return companiesDtos;


        } catch (Exception ex)
        {
            _loggerManager.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
            throw;
        }
    }

}