using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(Guid id);
        Task<Teacher> CreateAsync(Teacher entity);
        Task<Teacher> UpdateAsync(Guid id, Teacher updatedEntity);
        Task<bool> DeleteAsync(Guid id);
    }
}
