using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAll();
        Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<AssignmentDTO>> GetByPageByTeacherIdAsync(int id, AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentDTO> GetById(int id);
        Task<AssignmentDTO> Create(AssignmentCreateOrUpdateDTO request);
        Task<AssignmentDTO> Update(int id, AssignmentCreateOrUpdateDTO request);
        Task<bool> Delete(int id);
        Task<AssignmentDTO> RespondToAssignment(AssignmentResponseDTO dto, int userId);

    }
}