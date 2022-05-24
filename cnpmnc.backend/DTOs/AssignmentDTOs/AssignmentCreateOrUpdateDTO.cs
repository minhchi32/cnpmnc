using cnpmnc.backend.Models;

namespace cnpmnc.backend.DTOs.AssignmentDTOs;

public class AssignmentCreateOrUpdateDTO
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AssignToTeacherId { get; set; }
    public DateTime AssignDate { get; set; }
    public string Note { get; set; }
}