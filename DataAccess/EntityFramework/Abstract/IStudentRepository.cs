﻿using Entities;

namespace Data_Access.EntityFramework.Abstract
{
    public interface IStudentRepository : IEntityRepository<Student>
    {
        Task AddRangeAsync(IEnumerable<Student> entities);

    }
}
