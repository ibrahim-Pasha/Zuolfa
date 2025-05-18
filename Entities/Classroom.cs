using System.Text.Json.Serialization;

namespace Entities;

public class Classroom : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid CenterId { get; set; }
    [JsonIgnore]
    public Center? Center { get; set; }

    public Guid TeacherId { get; set; }
    [JsonIgnore]
    public Teacher? Teacher { get; set; }
    public ICollection<Student>? Students { get; set; }
}
