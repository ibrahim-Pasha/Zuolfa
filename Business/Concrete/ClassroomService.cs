using Business.Absttract;

using Data_Access.EntityFramework.Abstract;
using Entities;

namespace EducationPlatformAPI.Services
{
    public class ClassroomService : IClassroomService
    {

        private readonly IClassroomRepository _repository;

        public ClassroomService(IClassroomRepository repository)

        {
            _repository = repository;
        }

        public async Task<IEnumerable<Classroom>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Classroom> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Classroom> CreateAsync(Classroom entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<Classroom> UpdateAsync(Guid id, Classroom updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;
            if (updated.Students == null || updated.Students.Count < 1)
                throw new ArgumentException("Students count of class room must be more than 1");
            existing.CenterId = updated.CenterId;
            existing.TeacherId = updated.TeacherId;
            existing.Name = updated.Name;
            existing.Students = updated.Students;
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