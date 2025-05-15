using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;

public class Exercise:IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }

    public Guid LessonId { get; set; }
    [JsonIgnore]
    public Lesson? Lesson { get; set; }

    public required ICollection<ExerciseQuestion> Questions { get; set; }
}
