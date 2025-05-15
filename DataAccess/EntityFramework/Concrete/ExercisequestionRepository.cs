using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class ExerciseQuestionRepository: IExerciseQuestionRepository
    {
        private readonly ZuolfaContext _dbContext;

        public ExerciseQuestionRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ExerciseQuestion>> GetAllAsync()
         => await _dbContext.ExerciseQuestions.ToListAsync();

        public async Task<ExerciseQuestion> GetByIdAsync(Guid id)
            => await _dbContext.ExerciseQuestions.FindAsync(id);

        public async Task AddAsync(ExerciseQuestion exercisequestion)
            => await _dbContext.ExerciseQuestions.AddAsync(exercisequestion);

        public void Update(ExerciseQuestion exercisequestion)
            => _dbContext.ExerciseQuestions.Update(exercisequestion);

        public void Delete(ExerciseQuestion exercisequestion)
            => _dbContext.ExerciseQuestions.Remove(exercisequestion);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
