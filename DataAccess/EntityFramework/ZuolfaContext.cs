using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.EntityFramework
{
    public class ZuolfaContext:DbContext
    {
        public ZuolfaContext(DbContextOptions<ZuolfaContext> options) : base(options) { }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseQuestion> ExerciseQuestions { get; set; }
    }
}
