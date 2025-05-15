using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Lesson:IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Guid InstituteId { get; set; }
    public Institute Institute { get; set; }

    public ICollection<Exercise> Exercises { get; set; }

}
