using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.backend.Service
{

    public interface ITeacherService
    {
        Task<List<Account>> GetAll();
        Task<PagedResponseModel<TeacherDTO>> GetByPageAsync(TeacherQueryCriteria queryCriteria, CancellationToken cancellationToken);
        Task<TeacherDTO> GetById(int id);
        Task<TeacherDTO> Create(TeacherCreateOrUpdateDTO request);
        Task<TeacherDTO> Update(int id, TeacherCreateOrUpdateDTO request);
        Task<bool> Delete(int id);

    }
}