using AutoMapper;
using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Contracts;
using CompanyEmployees.Shared.DTOs;


namespace CompanyEmployees.Service;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public CompanyService(
        IRepositoryManager repositoryManager,
        ILoggerManager loggerManager,
        IMapper mapper
    )
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

            var companiesDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDtos;


        } catch (Exception ex)
        {
            _loggerManager.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
            throw;
        }
    }

}