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
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)

        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() => await _repository.GetAllAsync();


        public async Task<Student> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);


        public async Task<Student> CreateAsync(Student entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<List<Student>> CreateManyAsync(List<Student> students)
        {
            await _repository.AddRangeAsync(students);
            await _repository.SaveAsync();
            return students;
        }

        public async Task<Student> UpdateAsync(Guid id, Student reqStudent)

        {
            var domainStudent = await _repository.GetByIdAsync(id);
            if (domainStudent == null) return null;
            domainStudent.FullName=reqStudent.FullName;
            domainStudent.ClassroomId=reqStudent.ClassroomId;
            await _repository.SaveAsync();
            return reqStudent;
        }


        public async Task<bool> DeleteAsync(Guid id)

        {
            var domainStudent = await _repository.GetByIdAsync(id);
            if (domainStudent == null) return false;

            _repository.Delete(domainStudent);
            await _repository.SaveAsync();
            return true;
        }
    }
}