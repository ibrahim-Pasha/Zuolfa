using System.Text.Json.Serialization;

namespace Entities;

public class Center : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid InstituteId { get; set; }
    [JsonIgnore]
    public Institute? Institute { get; set; }
    [JsonIgnore]
    public ICollection<Classroom>? Classrooms { get; set; }
}
