using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Exercise:IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }

    public ICollection<ExerciseQuestion> Questions { get; set; }
}
