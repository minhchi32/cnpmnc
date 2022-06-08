using cnpmnc.backend.Models;

namespace cnpmnc.backend.DTOs.AssignmentGradeDTOs;

public class AssignmentGradeCreateOrUpdateDTO
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AssignToTeacherId { get; set; }
    public string Note { get; set; }
}