using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface IGradeService
    {
        Task<List<Grade>> GetAll();
        Task<PagedResponseModel<GradeDTO>> GetByPageAsync(GradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<GradeDTO>> GetByPageByTeacherIdAsync(int id, GradeQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<GradeDTO> GetById(int id);

    }
}