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

        public async Task<Teacher> UpdateAsync(Guid id, Teacher reqTeacher)
        {
            var domainTeacher = await _repository.GetByIdAsync(id);
            if (domainTeacher == null) return null;
            domainTeacher.FullName = reqTeacher.FullName;
            await _repository.SaveAsync();
            return reqTeacher;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var domainTeacher = await _repository.GetByIdAsync(id);
            if (domainTeacher == null) return false;

            _repository.Delete(domainTeacher);
            await _repository.SaveAsync();
            return true;
        }
    }
}
