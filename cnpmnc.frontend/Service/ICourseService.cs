using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.shared;

namespace cnpmnc.frontend.Service
{
    public interface ICourseService
    {
        Task<PagedResponseModel<CourseDTO>> GetByPageAsync(CourseQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<CourseDTO> GetById(int id);
        Task<CourseDTO> CreateOrUpdate(CourseCreateOrUpdateDTO request, int id = 0);
        Task<bool> Delete(int id);
    }
}