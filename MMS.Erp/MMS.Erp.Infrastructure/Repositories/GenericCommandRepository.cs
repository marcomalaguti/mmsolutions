
using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.Repositories;
using System.Linq.Expressions;

namespace MMS.Erp.Infrastructure.Repositories;

public class GenericCommandRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ErpDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericCommandRepository(ErpDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}