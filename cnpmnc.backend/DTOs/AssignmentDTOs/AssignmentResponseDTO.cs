using cnpmnc.shared.Enums;

namespace cnpmnc.backend.DTOs.AssignmentDTOs;

public class AssignmentResponseDTO
{
    public int AssignmentID { get; set; }
    public AssignmentResponseEnumDto Response { get; set; }
}