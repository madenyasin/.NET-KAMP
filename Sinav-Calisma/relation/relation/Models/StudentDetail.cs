namespace relation.Models
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}