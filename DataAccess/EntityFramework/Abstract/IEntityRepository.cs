using Entities;
using System.Linq.Expressions;

namespace Data_Access.EntityFramework.Abstract
{

    public interface IEntityRepository<T> where T : class, IEntity

    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
