using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Okul.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public StudentDetail? StudentDetail { get; set; }

        public ICollection<StudentCourse>? Courses { get; set; } = new List<StudentCourse>();
    }

    public class StudentDetail
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public int StudentId { get; set; }

        public Student? Student { get; set; }
    }

    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Course>? Courses { get; set; } = new List<Course>();
    }

    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        public ICollection<StudentCourse>? Students { get; set; } = new List<StudentCourse>();
    }

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student? Student{ get; set; }
        public Course? Course{ get; set; }
    }
}
