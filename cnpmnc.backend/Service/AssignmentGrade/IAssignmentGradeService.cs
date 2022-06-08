using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface IAssignmentGradeService
    {
        Task<List<AssignmentGrade>> GetAll();
        Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageAsync(AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageByTeacherIdAsync(int id, AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<AssignmentGradeDTO> GetById(int id);
        Task<AssignmentGradeDTO> Create(AssignmentGradeCreateOrUpdateDTO request);
        Task<AssignmentGradeDTO> Update(int id, AssignmentGradeCreateOrUpdateDTO request);
        Task<bool> Delete(int id);
        Task<AssignmentGradeDTO> RespondToAssignmentGrade(AssignmentGradeResponseDTO dto, int userId);

    }
}