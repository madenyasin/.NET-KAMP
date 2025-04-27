using Microsoft.EntityFrameworkCore;
using relation.Models;

namespace relation.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected CourseDbContext()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
