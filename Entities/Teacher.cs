using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Teacher:IEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public ICollection<Classroom> Classrooms { get; set; }
}
