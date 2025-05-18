using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface IExerciseQuestionService
    {
        Task<IEnumerable<ExerciseQuestion>> GetAllAsync();
        Task<ExerciseQuestion> GetByIdAsync(Guid id);
        Task<ExerciseQuestion> CreateAsync(ExerciseQuestion entity);
        Task<ExerciseQuestion> UpdateAsync(Guid id, ExerciseQuestion updatedEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ExerciseQuestion>> CreateManyAsync(List<ExerciseQuestion> exerciseQuestion);
        Task<IEnumerable<ExerciseQuestion>> GetArchivedAsync();


    }
}
