﻿using Business.Absttract;

using Data_Access.EntityFramework.Abstract;
using Entities;

namespace Business.Concrete
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _repository;

        public ExerciseService(IExerciseRepository repository)

        {
            _repository = repository;
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Exercise> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Exercise> CreateAsync(Exercise entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<Exercise> UpdateAsync(Guid id, Exercise updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Title = updated.Title;
            existing.Questions = updated.Questions;
            existing.LessonId = updated.LessonId;
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

        public async Task<IEnumerable<Exercise>> GetArchivedAsync()
        
            => await _repository.GetArchivedAsync();
        
    }
}
