using cnpmnc.backend.Models;

namespace cnpmnc.backend.DTOs.TeacherDTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string IdCard { get; set; }
        public int PhoneNumber { get; set; }
        public int LiteracyId { get; set; }
        public Literacy Literacy { get; set; }
        public List<AssignmentGrade>? AssignmentGrades { get; set; }
        public int? NumberOfHoursInClass { get; set; }
        public int? ActualNumberOfHoursInClass { get; set; }
        public int? NumberOfTeachingSessions { get; set; }
        public int? NumberOfBreaks { get; set; }
    }
}