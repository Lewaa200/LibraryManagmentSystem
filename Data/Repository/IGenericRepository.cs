using Data.Models;
using Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<PaginatedList<T>> GetPaginatedListAsync(int pageIndex, int pageSize);

    Task<PaginatedList<T>> GetPaginatedListAsync(
           int pageIndex, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);


    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
