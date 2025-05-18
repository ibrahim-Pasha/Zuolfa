using Business.Absttract;

using Data_Access.EntityFramework.Abstract;
using Entities;

namespace Business.Concrete
{
    public class ExerciseQuestionService : IExerciseQuestionService
    {

        private readonly IExerciseQuestionRepository _repository;

        public ExerciseQuestionService(IExerciseQuestionRepository repository)

        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExerciseQuestion>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<ExerciseQuestion> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<ExerciseQuestion> CreateAsync(ExerciseQuestion entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<List<ExerciseQuestion>> CreateManyAsync(List<ExerciseQuestion> exerciseQuestion)
        {
            await _repository.AddRangeAsync(exerciseQuestion);
            await _repository.SaveAsync();
            return exerciseQuestion;
        }

        public async Task<ExerciseQuestion> UpdateAsync(Guid id, ExerciseQuestion updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;
            existing.QuestionText = updated.QuestionText;
            existing.ExerciseId = updated.ExerciseId;
            existing.isArchived = updated.isArchived;
            await _repository.SaveAsync();
            return updated;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            _repository.Delete(existing);
            await _repository.SaveAsync();
            return true;
        }
        public async Task<IEnumerable<ExerciseQuestion>> GetArchivedAsync()

          => await _repository.GetArchivedAsync();
    }
}
