using Business.Absttract;
using Data_Access.EntityFramework.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Teacher> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<Teacher> UpdateAsync(Guid id, Teacher updated)
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
