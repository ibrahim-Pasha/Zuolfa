using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{

    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(Guid id);
        Task<Exercise> CreateAsync(Exercise entity);
        Task<Exercise> UpdateAsync(Guid id, Exercise updatedEntity);
        Task<bool> DeleteAsync(Guid id);
    }
}
