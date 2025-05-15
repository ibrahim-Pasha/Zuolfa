using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;

public class Lesson:IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }

    public Guid InstituteId { get; set; }
    [JsonIgnore]
    public Institute? Institute { get; set; }
    [JsonIgnore]
    public ICollection<Exercise>? Exercises { get; set; }

}
