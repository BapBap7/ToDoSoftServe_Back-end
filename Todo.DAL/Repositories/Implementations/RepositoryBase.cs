using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Todo.DAL.Persistence;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.DAL.Repositories.Implementations;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly ToDoDbContext _dbContext;

    protected RepositoryBase(ToDoDbContext context)
    {
        _dbContext = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var tmp = await _dbContext.Set<T>().AddAsync(entity);
        return tmp.Entity;
    }


    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public EntityEntry<T> Update(T entity)
    {
        return _dbContext.Set<T>().Update(entity);
    }

    public async Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default)
    {
        return await GetQueryable(predicate, include).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>?> GetAllAsync(
        Expression<Func<T, T>> selector,
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default)
    {
        return await GetQueryable(predicate, include).Select(selector).ToListAsync() ?? new List<T>();
    }
    
    private IQueryable<T> GetQueryable(
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default,
        Expression<Func<T, T>>? selector = default)
    {
        var query = _dbContext.Set<T>().AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (selector is not null)
        {
            query = query.Select(selector);
        }

        return query.AsNoTracking();
    }
}