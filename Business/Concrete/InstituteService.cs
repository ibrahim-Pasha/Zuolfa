using Business.Absttract;
using Data_Access.EntityFramework.Abstract;
using Entities;

namespace Business.Concrete
{
    public class InstituteService : IInstituteService
    {
        private readonly IInstituteRepository _repository;

        public InstituteService(IInstituteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Institute>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Institute> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Institute> CreateAsync(Institute institute)
        {
            if (institute.Lessons == null || institute.Lessons.Count < 5)
                throw new ArgumentException("institute must have min 5 Lessons");

            await _repository.AddAsync(institute);
            await _repository.SaveAsync();
            return institute;
        }

        public async Task<Institute> UpdateAsync(Guid id, Institute updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            if (updated.Lessons == null || updated.Lessons.Count < 5)
                throw new ArgumentException("institute must have min 5 Lessons");

            existing.Name = updated.Name;
            existing.Lessons = updated.Lessons;

            _repository.Update(existing);
            await _repository.SaveAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            _repository.Delete(existing);
            await _repository.SaveAsync();
            return true;
        }
    }

}
