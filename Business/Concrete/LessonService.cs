using Business.Absttract;
using Data_Access.EntityFramework.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repository;

        public LessonService(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Lesson> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Lesson> CreateAsync(Lesson entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<Lesson> UpdateAsync(Guid id, Lesson updated)
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