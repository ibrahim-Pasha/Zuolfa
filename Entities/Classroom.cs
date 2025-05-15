using System.Text.Json.Serialization;

namespace Entities;

public class Classroom : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid CenterId { get; set; }
    public Center? Center { get; set; }

    public Guid TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    [JsonRequired]
    public required ICollection<Student> Students { get; set; }
}
