using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(Guid id);
        Task<Student> CreateAsync(Student entity);
        Task<Student> UpdateAsync(Guid id, Student updatedEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Student>> CreateManyAsync(List<Student> student);

    }
}