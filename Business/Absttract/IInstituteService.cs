using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface IInstituteService
    {
        Task<IEnumerable<Institute>> GetAllAsync();
        Task<Institute> GetByIdAsync(Guid id);
        Task<Institute> CreateAsync(Institute institute);
        Task<Institute> UpdateAsync(Guid id, Institute updatedInstitute);
        Task<bool> DeleteAsync(Guid id);
    }
}
