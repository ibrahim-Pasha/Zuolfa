using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Center:IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }

    public ICollection<Classroom> Classrooms { get; set; }
}
