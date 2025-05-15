using Business.Absttract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuolfaWebApi.Data_Access.Concrete;

namespace EducationPlatformAPI.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly ClassroomRepository _repository;

        public ClassroomService(ClassroomRepository repository)
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