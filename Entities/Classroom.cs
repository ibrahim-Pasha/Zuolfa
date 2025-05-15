using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Classroom:IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid CenterId { get; set; }
    public Center Center { get; set; }

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public ICollection<Student> Students { get; set; }
}
