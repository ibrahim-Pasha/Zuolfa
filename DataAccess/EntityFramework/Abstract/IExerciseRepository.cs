﻿using Entities;

namespace Data_Access.EntityFramework.Abstract
{
    public interface IExerciseRepository : IEntityRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetArchivedAsync();

    }
}
