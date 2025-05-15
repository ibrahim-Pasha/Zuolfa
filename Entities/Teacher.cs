using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;

public class Teacher:IEntity
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    [JsonIgnore]
    public ICollection<Classroom>? Classrooms { get; set; }
}
