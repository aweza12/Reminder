using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DL.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ReminderDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(ReminderDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public virtual async Task<List<T>> GetListAsync(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "",
			bool isTracking = true)
		{
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
						 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return isTracking ? await orderBy(query).ToListAsync() : await orderBy(query).AsNoTracking().ToListAsync();
			}

			List<T> result;
			if (isTracking)
			{
				result = await query.ToListAsync();
			}
			else
			{
				result = await query.AsNoTracking().ToListAsync();
			}

			return result;
		}

		public virtual async Task<T?> GetFirstAsync(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "",
			bool isTracking = true)
		{
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
						 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty.Trim());
			}

			if (orderBy != null)
			{
				if (isTracking)
				{
					T result = await orderBy(query).FirstOrDefaultAsync();
					return result;
				}
				else
				{
					T result = await orderBy(query).AsNoTracking().FirstOrDefaultAsync();
					return result;
				}
			}

			if (isTracking)
			{
				T result = await query.FirstOrDefaultAsync();
				return result;
			}
			else
			{
				T result = await query.AsNoTracking().FirstOrDefaultAsync();
				return result;
			}
		}

		public virtual async Task<T?> GetByIdAsync(int id)
		{
			var result = await _dbSet.FindAsync(id);
			return result;
		}

		public virtual async Task InsertAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public virtual async Task DeleteAsync(int id)
		{
			var entityToDelete = await _dbSet.FindAsync(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(T? entityToDelete)
		{
			if (entityToDelete == null) return;

			if (_context.Entry(entityToDelete).State == EntityState.Detached)
			{
				_dbSet.Attach(entityToDelete);
			}

			_dbSet.Remove(entityToDelete);
		}

		public virtual void Update(T entityToUpdate)
		{
			_dbSet.Attach(entityToUpdate);
			_context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public DbSet<T> CustomQuery()
		{
			return _dbSet;
		}

		public async Task<int> Count(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			var result = await query.CountAsync();
			return result;
		}
	}
}
