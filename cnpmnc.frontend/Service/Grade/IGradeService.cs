using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.shared;

namespace cnpmnc.frontend.Service
{
    public interface IGradeService
    {
        Task<PagedResponseModel<GradeDTO>> GetByPageAsync(GradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<GradeDTO>> GetByPageByIdAsync(int id, GradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
    }
}