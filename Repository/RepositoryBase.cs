
using System.Linq.Expressions;
using CompanyEmployees.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext _repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

    public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);


    public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            _repositoryContext.Set<T>()
            .AsNoTracking()
            :
            _repositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges ?
              _repositoryContext.Set<T>()
              .Where(expression)
              .AsNoTracking()
          :
              _repositoryContext.Set<T>().Where(expression);
    }

}