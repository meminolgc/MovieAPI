using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Repositories;
using MovieAPI.Domain.Entities.Common;
using MovieAPI.Persistence.Contexts;
using System.Linq.Expressions;

namespace MovieAPI.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		private readonly MovieAPIDbContext _context;

		public ReadRepository(MovieAPIDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll() => Table;

		public async Task<T> GetByIdAsync(int id) 
			=> await Table.FindAsync(id);

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
			=> await Table.FirstOrDefaultAsync(method);

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);
		
	}
}
