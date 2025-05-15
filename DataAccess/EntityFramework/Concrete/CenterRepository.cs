using Entities;
using Microsoft.EntityFrameworkCore;
using Data_Access.EntityFramework.Abstract;
using Data_Access.EntityFramework;

namespace ZuolfaWebApi.Data_Access.Concrete
{
    public class CenterRepository : ICenterRepository
    {
        private readonly ZuolfaContext _dbContext;

        public CenterRepository(ZuolfaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Center>> GetAllAsync()
         => await _dbContext.Centers.ToListAsync();

        public async Task<Center> GetByIdAsync(Guid id)
            => await _dbContext.Centers.FindAsync(id);

        public async Task AddAsync(Center center)
            => await _dbContext.Centers.AddAsync(center);

        public void Update(Center center)
            => _dbContext.Centers.Update(center);

        public void Delete(Center center)
            => _dbContext.Centers.Remove(center);
        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
