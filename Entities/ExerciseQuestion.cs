using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class ExerciseQuestion:IEntity
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }

    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
}
