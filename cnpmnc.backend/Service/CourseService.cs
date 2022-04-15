using cnpmnc.backend.Data;
using cnpmnc.backend.Models;

namespace cnpmnc.backend.Service;

class CourseService : ICourseService
{

    readonly ApplicationDbContext context;
    public CourseService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Task<Course> Create()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Course>> GetAll()
    {
        return context.Courses.ToList();
    }

    public Task<Course> Update()
    {
        throw new NotImplementedException();
    }
}