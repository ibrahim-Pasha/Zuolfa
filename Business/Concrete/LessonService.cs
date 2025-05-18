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
        public async Task<List<Lesson>> CreateManyAsync(List<Lesson> lessons)
        {
            var existingCount = await _repository.CountAsync();
            if (existingCount + lessons.Count <= 4)
            {
                throw new InvalidOperationException("Total Count Of Lessons must be more than 4");
            }
            await _repository.AddRangeAsync(lessons);
            await _repository.SaveAsync();
            return lessons;
        }

        public async Task<Lesson> UpdateAsync(Guid id, Lesson reqLesson)
        {
            var domainLesson = await _repository.GetByIdAsync(id);
            if (domainLesson == null) return null;
            domainLesson.Title=reqLesson.Title;
            domainLesson.InstituteId=reqLesson.InstituteId;
            await _repository.SaveAsync();
            return reqLesson;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingCount = await _repository.CountAsync();
            if (existingCount -1 <= 4)
            {
                throw new InvalidOperationException("Total Count Of Lessons must be more than 4");
            }
            var domainLesson = await _repository.GetByIdAsync(id);
            if (domainLesson == null) return false;

            _repository.Delete(domainLesson);
            await _repository.SaveAsync();
            return true;
        }
    }
}