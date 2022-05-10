using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.shared;

namespace cnpmnc.frontend.Service
{
    public interface ITeacherService
    {
        Task<PagedResponseModel<TeacherDTO>> GetByPageAsync(TeacherQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<TeacherDTO> GetById(int id);
        Task<TeacherDTO> CreateOrUpdate(TeacherCreateOrUpdateDTO request, int id = 0);
        Task<bool> Delete(int id);
    }
}