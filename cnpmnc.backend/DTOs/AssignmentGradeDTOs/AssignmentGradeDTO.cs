using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;

namespace cnpmnc.backend.DTOs.AssignmentGradeDTOs
{
    public class AssignmentGradeDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AssignToTeacherId { get; set; }
        public Account Teacher { get; set; }
        public AssignmentGradeStateEnumDto State { get; set; }
        public string Note { get; set; }
        public DateTime AssignDate { get; set; }
        public int Total { get; set; }
    }
}