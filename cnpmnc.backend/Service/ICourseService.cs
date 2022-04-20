using cnpmnc.backend.DTOs.Course;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface ICourseService
    {
        Task<List<Course>> GetAll();
        Task<PagedResponseModel<CourseDTO>> GetByPageAsync(CourseQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<CourseDTO> GetById(int id);
        Task<CourseDTO> Create(CourseCreateDTO request);
        Task<CourseDTO> Update(int id, CourseUpdateDTO request);
        Task<bool> Delete(int id);

    }
}