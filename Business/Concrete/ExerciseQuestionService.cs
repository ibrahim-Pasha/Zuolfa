using Business.Absttract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuolfaWebApi.Data_Access.Concrete;

namespace Business.Concrete
{
    public class ExerciseQuestionService:IExerciseQuestionService
    {
        private readonly ExerciseQuestionRepository _repository;

        public ExerciseQuestionService(ExerciseQuestionRepository repository)
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

        public async Task<ExerciseQuestion> UpdateAsync(Guid id, ExerciseQuestion updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _repository.Update(updated);
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
    }
}
