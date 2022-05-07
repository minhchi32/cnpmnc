using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface ICourseService
    {
        Task<List<Course>> GetAll();
        Task<PagedResponseModel<CourseDTO>> GetByPageAsync(CourseQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<CourseDTO> GetById(int id);
        Task<CourseDTO> Create(CourseCreateOrUpdateDTO request);
        Task<CourseDTO> Update(int id, CourseCreateOrUpdateDTO request);
        Task<bool> Delete(int id);

    }
}