using cnpmnc.shared.Enums;

namespace cnpmnc.backend.DTOs.AssignmentDTOs;

public class AssignmentGradeResponseDTO
{
    public int AssignmentGradeID { get; set; }
    public AssignmentGradeResponseEnumDto Response { get; set; }
}