using System.Text.Json.Serialization;

namespace Entities
{
    public class Institute : IEntity
    {
        public Guid Id { get; set; }
        [JsonRequired]
        public required string Name { get; set; }
        [JsonRequired]
        public required ICollection<Center> Centers { get; set; }
        [JsonRequired]
        public required ICollection<Lesson> Lessons { get; set; }
    }
}
