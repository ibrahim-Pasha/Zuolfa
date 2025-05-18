using Entities;

namespace Data_Access.EntityFramework.Abstract
{
    public interface IExerciseQuestionRepository : IEntityRepository<ExerciseQuestion>
    {
        Task AddRangeAsync(IEnumerable<ExerciseQuestion> entities);
        Task<IEnumerable<ExerciseQuestion>> GetArchivedAsync();

    }
}
