using System.Text.Json.Serialization;

namespace Entities;

public class ExerciseQuestion : IEntity
{
    public Guid Id { get; set; }
    public required string QuestionText { get; set; }

    public Guid ExerciseId { get; set; }
    [JsonIgnore]
    public Exercise? Exercise { get; set; }
    public bool isArchived { get; set; }

}
