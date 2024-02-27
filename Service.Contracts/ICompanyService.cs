using CompanyEmployees.Shared.DTOs;

namespace CompanyEmployees.Service.Contracts;

public interface ICompanyService
{
    IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
}