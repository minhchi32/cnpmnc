using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Enums;

namespace cnpmnc.frontend.Service
{
    public interface IAssignmentGradeService
    {
        Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageAsync(AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentGradeDTO> GetById(int id);
        Task<AssignmentGradeDTO> CreateOrUpdate(AssignmentGradeCreateOrUpdateDTO request, int id = 0);
        Task<bool> Delete(int id);
        Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageByIdAsync(int id, AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentGradeDTO> RespondToAssignmentGrade(int userId, int assignmentGradeId, AssignmentGradeResponseEnumDto request);
    }
}