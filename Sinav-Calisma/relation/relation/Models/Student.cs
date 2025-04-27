namespace relation.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentDetail? StudentDetail { get; set; }
        public ICollection<StudentCourse>? Courses { get; set; } = new List<StudentCourse>();
    }
}
