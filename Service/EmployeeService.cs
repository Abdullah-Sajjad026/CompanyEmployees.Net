using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Contracts;

namespace CompanyEmployees.Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public EmployeeService(
        IRepositoryManager repositoryManager,
        ILoggerManager loggerManager
    )
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }
}