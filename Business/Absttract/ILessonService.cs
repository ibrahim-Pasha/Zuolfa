using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Lesson> GetByIdAsync(Guid id);
        Task<Lesson> CreateAsync(Lesson entity);
        Task<Lesson> UpdateAsync(Guid id, Lesson updatedEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Lesson>> CreateManyAsync(List<Lesson> lessons);

    }
}