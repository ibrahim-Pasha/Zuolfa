using Entities;

namespace Data_Access.EntityFramework.Abstract
{
    public interface ILessonRepository : IEntityRepository<Lesson>
    {
        Task AddRangeAsync(IEnumerable<Lesson> entities);
        Task<int> CountAsync();

    }
}
