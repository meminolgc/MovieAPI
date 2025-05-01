using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<T> AddAsync(T entity);
		Task<bool> RemoveAsync(int id);
		bool Remove(T entity);
		bool RemoveRange(List<T> datas);
		bool Update(T entity);
		Task<int> SaveAsync();
	}
}
