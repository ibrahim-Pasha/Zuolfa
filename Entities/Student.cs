using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Student:IEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public Guid ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
}
