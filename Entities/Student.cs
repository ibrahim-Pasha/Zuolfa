using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;

public class Student:IEntity
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }

    public Guid ClassroomId { get; set; }
    [JsonIgnore]
    public Classroom? Classroom { get; set; }
}
