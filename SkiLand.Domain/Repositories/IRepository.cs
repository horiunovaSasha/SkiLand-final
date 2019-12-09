using SkiLand.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkiLand.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity> FindById(long id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(long id);
        Task SaveChanges();
    }
}
