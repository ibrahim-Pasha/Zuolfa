using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ZuolfaContext _dbContext;

        public LessonRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Lesson>> GetAllAsync()
         => await _dbContext.Lessons.ToListAsync();

        public async Task<Lesson> GetByIdAsync(Guid id)
            => await _dbContext.Lessons.FindAsync(id);

        public async Task AddAsync(Lesson lesson)
            => await _dbContext.Lessons.AddAsync(lesson);

        public void Update(Lesson lesson)
            => _dbContext.Lessons.Update(lesson);

        public void Delete(Lesson lesson)
            => _dbContext.Lessons.Remove(lesson);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
