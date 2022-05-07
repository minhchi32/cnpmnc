using AutoMapper;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.backend.Extensions;
using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Exceptions;
using cnpmnc.shared.Interfaces;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class CourseService : ICourseService
{

    private readonly IBaseRepository<Course> _courseRepository;
    private readonly IMapper _mapper;
    public CourseService(
        IBaseRepository<Course> courseRepository,
        IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponseModel<CourseDTO>> GetByPageAsync(
           CourseQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _courseRepository.Entities.AsQueryable(),
            queryCriteria);

        var courses = await query
            .AsNoTracking()
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<CourseDTO>>(courses.Items);

        return new PagedResponseModel<CourseDTO>
        {
            Page = courses.Page,
            //TotalPages = courses.TotalPages,
            TotalRecord = courses.TotalRecord,
            Items = dtos
        };
    }
    public async Task<CourseDTO> Create(CourseCreateOrUpdateDTO request)
    {
        Ensure.Any.IsNotNull(request);

        var newCourse = _mapper.Map<Course>(request);

        var result = await _courseRepository.Add(newCourse);
        if (result != null)
        {
            return _mapper.Map<CourseDTO>(newCourse);
        }
        return null;
    }

    public async Task<CourseDTO> Update(int id, CourseCreateOrUpdateDTO request)
    {
        var course = await _courseRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

        if (course == null)
        {
            throw new NotFoundException("Not Found!");
        }

        course = _mapper.Map<CourseCreateOrUpdateDTO, Course>(request, course);

        var courseUpdated = await _courseRepository.Update(course);

        var courseUpdatedDTO = _mapper.Map<CourseDTO>(courseUpdated);

        return courseUpdatedDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var course = await _courseRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (course == null)
        {
            throw new NotFoundException("Not Found!");
        }
        course.IsDeleted = true;

        var courseDelete = await _courseRepository.Update(course);

        return courseDelete.IsDeleted;
    }

    public Task<List<Course>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<CourseDTO> GetById(int id)
    {
        var course = await _courseRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (course == null)
        {
            throw new NotFoundException("Not Found!");
        }
        return _mapper.Map<CourseDTO>(course);
    }

    private IQueryable<Course> Filter(
        IQueryable<Course> query,
        CourseQueryCriteria queryCriteria)
    {
        if (!String.IsNullOrEmpty(queryCriteria.Search))
        {
            query = query.Where(b =>
                b.Name.Contains(queryCriteria.Search)
                );
        }
        query = query.Where(x => x.IsDeleted == false);

        return query.AsQueryable();
    }
}