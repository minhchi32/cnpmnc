using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Enums;

namespace cnpmnc.frontend.Service
{
    public interface IAssignmentService
    {
        Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentDTO> GetById(int id);
        Task<AssignmentDTO> CreateOrUpdate(AssignmentCreateOrUpdateDTO request, int id = 0);
        Task<bool> Delete(int id);
        Task<PagedResponseModel<AssignmentDTO>> GetByPageByIdAsync(int id, AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentDTO> RespondToAssignment(int userId, int assignmentId, AssignmentResponseEnumDto request);
    }
}