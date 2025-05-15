using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absttract
{
    public interface ICenterService
    {
        Task<IEnumerable<Center>> GetAllAsync();
        Task<Center> GetByIdAsync(Guid id);
        Task<Center> CreateAsync(Center center);
        Task<Center> UpdateAsync(Guid id, Center updatedCenter);
        Task<bool> DeleteAsync(Guid id);
    }

}
