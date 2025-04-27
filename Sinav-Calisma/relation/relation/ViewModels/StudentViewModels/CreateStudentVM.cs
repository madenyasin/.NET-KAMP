namespace relation.ViewModels.Student
{
    public class CreateStudentVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<int> SecilenKursIdleri { get; set; } = new();
    }
}
