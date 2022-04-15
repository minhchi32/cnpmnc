using cnpmnc.backend.Models;

namespace cnpmnc.backend.Service;

public interface ICourseService{
    Task<List<Course>> GetAll();
    Task<Course> Create();
    Task<Course> Update();
}