using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface IClassroomService
    {
        Task<IEnumerable<Classroom>> GetAllAsync();
        Task<Classroom> GetByIdAsync(Guid id);
        Task<Classroom> CreateAsync(Classroom entity);
        Task<Classroom> UpdateAsync(Guid id, Classroom updatedEntity);
        Task<bool> DeleteAsync(Guid id);
    }
}