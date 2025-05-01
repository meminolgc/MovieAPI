using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities.Common;
using System.Collections.Generic;

namespace MovieAPI.Application.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}
