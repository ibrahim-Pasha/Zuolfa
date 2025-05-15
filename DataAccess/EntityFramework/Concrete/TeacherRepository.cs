using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ZuolfaContext _dbContext;

        public TeacherRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Teacher>> GetAllAsync()
         => await _dbContext.Teachers.ToListAsync();

        public async Task<Teacher> GetByIdAsync(Guid id)
            => await _dbContext.Teachers.FindAsync(id);

        public async Task AddAsync(Teacher teacher)
            => await _dbContext.Teachers.AddAsync(teacher);

        public void Update(Teacher teacher)
            => _dbContext.Teachers.Update(teacher);

        public void Delete(Teacher teacher)
            => _dbContext.Teachers.Remove(teacher);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
