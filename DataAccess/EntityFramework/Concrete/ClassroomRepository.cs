using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class ClassroomRepository:IClassroomRepository
    {
        private readonly ZuolfaContext _dbContext;

        public ClassroomRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Classroom>> GetAllAsync()
         => await _dbContext.Classrooms.ToListAsync();

        public async Task<Classroom> GetByIdAsync(Guid id)
            => await _dbContext.Classrooms.FindAsync(id);

        public async Task AddAsync(Classroom classroom)
            => await _dbContext.Classrooms.AddAsync(classroom);

        public void Update(Classroom classroom)
            => _dbContext.Classrooms.Update(classroom);

        public void Delete(Classroom classroom)
            => _dbContext.Classrooms.Remove(classroom);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
