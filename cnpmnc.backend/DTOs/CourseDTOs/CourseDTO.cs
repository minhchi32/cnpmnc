namespace cnpmnc.backend.DTOs.CourseDTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Detail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StudyConditions { get; set; }
        public int Tuition { get; set; }
    }
}