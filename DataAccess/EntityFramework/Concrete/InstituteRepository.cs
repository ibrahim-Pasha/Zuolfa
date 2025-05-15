using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;


namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly ZuolfaContext _dbContext;

        public InstituteRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Institute>> GetAllAsync()
         => await _dbContext.Institutes.ToListAsync();

        public async Task<Institute> GetByIdAsync(Guid id)
            => await _dbContext.Institutes.FindAsync(id);

        public async Task AddAsync(Institute institute)
            => await _dbContext.Institutes.AddAsync(institute);

        public void Update(Institute institute)
            => _dbContext.Institutes.Update(institute);

        public void Delete(Institute institute)
            => _dbContext.Institutes.Remove(institute);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
