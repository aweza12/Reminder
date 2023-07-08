using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DL.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetListAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "",
        bool isTracking = true);

        public Task<T?> GetFirstAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool isTracking = true);

        /*Task<List<U>> GetListAsync<U>(IQueryable<U> query);

        Task<int> GetCountAsync<U>(IQueryable<U> query);*/

        public Task<T?> GetByIdAsync(int id);

        public Task InsertAsync(T entity);

        public Task DeleteAsync(int id);

        public void Delete(T? entityToDelete);

        public void Update(T entityToUpdate);

        public DbSet<T> CustomQuery();
        public Task<int> Count(Expression<Func<T, bool>> filter = null);
    }
}
