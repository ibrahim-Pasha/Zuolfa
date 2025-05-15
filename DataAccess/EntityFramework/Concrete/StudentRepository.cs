using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ZuolfaContext _dbContext;

        public StudentRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
         => await _dbContext.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(Guid id)
            => await _dbContext.Students.FindAsync(id);

        public async Task AddAsync(Student student)
            => await _dbContext.Students.AddAsync(student);

        public void Update(Student student)
            => _dbContext.Students.Update(student);

        public void Delete(Student student)
            => _dbContext.Students.Remove(student);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
