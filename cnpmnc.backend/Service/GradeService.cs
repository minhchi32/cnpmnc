using AutoMapper;
using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.backend.Extensions;
using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Enums;
using cnpmnc.shared.Exceptions;
using cnpmnc.shared.Interfaces;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class GradeService : IGradeService
{

    private readonly IBaseRepository<Grade> _gradeRepository;
    private readonly IMapper _mapper;
    public GradeService(
        IBaseRepository<Grade> gradeRepository,
        IMapper mapper)
    {
        _gradeRepository = gradeRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponseModel<GradeDTO>> GetByPageAsync(
           GradeQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _gradeRepository.Entities.AsQueryable(),
            queryCriteria);

        var grades = await query
            .AsNoTracking()
            .Include(x => x.Course)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<GradeDTO>>(grades.Items);

        return new PagedResponseModel<GradeDTO>
        {
            Page = grades.Page,
            TotalRecord = grades.TotalRecord,
            Items = dtos
        };
    }

    public async Task<PagedResponseModel<GradeDTO>> GetByPageByTeacherIdAsync(
            int id,
           GradeQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _gradeRepository.Entities.AsQueryable(),
            queryCriteria);

        var grades = await query
            .AsNoTracking()
            .Where(x => x.TeacherId == id)
            .Include(x => x.Course)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<GradeDTO>>(grades.Items);

        return new PagedResponseModel<GradeDTO>
        {
            Page = grades.Page,
            TotalRecord = grades.TotalRecord,
            Items = dtos
        };
    }

    public Task<List<Grade>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<GradeDTO> GetById(int id)
    {
        var teacher = await _gradeRepository.Entities.Where(x => x.Id == id).Include(x => x.Course).FirstOrDefaultAsync();
        if (teacher == null)
        {
            throw new NotFoundException("Not Found!");
        }
        return _mapper.Map<GradeDTO>(teacher);
    }

    private IQueryable<Grade> Filter(
        IQueryable<Grade> query,
        GradeQueryCriteria queryCriteria)
    {
        if (!String.IsNullOrEmpty(queryCriteria.Search))
        {
            query = query.Where(b =>
                b.Name.Contains(queryCriteria.Search)
                );
        }

        return query.AsQueryable();
    }
}