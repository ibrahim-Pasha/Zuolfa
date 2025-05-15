using Business.Absttract;
using Data_Access.EntityFramework.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _repository;

        public CenterService(ICenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Center>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Center> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<Center> CreateAsync(Center center)
        {
            await _repository.AddAsync(center);
            await _repository.SaveAsync();
            return center;
        }

        public async Task<Center> UpdateAsync(Guid id, Center updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.InstituteId = updated.InstituteId;

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
