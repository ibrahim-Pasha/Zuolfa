namespace Entities
{
    public class Institute : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Center> Centers { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
