namespace relation.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<StudentCourse>? Students { get; set; } = new List<StudentCourse>();
    }

}
