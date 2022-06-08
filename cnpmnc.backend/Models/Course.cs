namespace cnpmnc.backend.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Detail { get; set; }
        public string StudyConditions { get; set; }
        public int Tuition { get; set; }
        public int NumberOfLesson { get; set; }
        public List<AssignmentGrade> AssignmentGrades { get; set; }
    }
}

