﻿using MovieAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace MovieAPI.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
		Task<T> GetByIdAsync(int id);
	}
}
