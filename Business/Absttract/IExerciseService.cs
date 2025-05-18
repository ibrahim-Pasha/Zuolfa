using Entities;

namespace Business.Absttract
{

    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(Guid id);
        Task<Exercise> CreateAsync(Exercise entity);
        Task<Exercise> UpdateAsync(Guid id, Exercise updatedEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<Exercise>> GetArchivedAsync();

    }
}
