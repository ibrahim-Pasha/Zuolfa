using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ZuolfaContext _dbContext;

        public ExerciseRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Exercise>> GetAllAsync()
         => await _dbContext.Exercises.ToListAsync();

        public async Task<Exercise> GetByIdAsync(Guid id)
            => await _dbContext.Exercises.FindAsync(id);

        public async Task AddAsync(Exercise exercise)
            => await _dbContext.Exercises.AddAsync(exercise);

        public void Update(Exercise exercise)
            => _dbContext.Exercises.Update(exercise);

        public void Delete(Exercise exercise)
            => _dbContext.Exercises.Remove(exercise);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
