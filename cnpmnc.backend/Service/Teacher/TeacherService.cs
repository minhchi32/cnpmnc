using AutoMapper;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.backend.Extensions;
using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Enums;
using cnpmnc.shared.Exceptions;
using cnpmnc.shared.Interfaces;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class TeacherService : ITeacherService
{

    private readonly IBaseRepository<Account> _teacherRepository;
    private readonly IMapper _mapper;
    public TeacherService(
        IBaseRepository<Account> teacherRepository,
        IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponseModel<TeacherDTO>> GetByPageAsync(
           TeacherQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _teacherRepository.Entities.AsQueryable(),
            queryCriteria);

        var teachers = await query
            .AsNoTracking()
            .Include(x => x.Literacy)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<TeacherDTO>>(teachers.Items);

        return new PagedResponseModel<TeacherDTO>
        {
            Page = teachers.Page,
            TotalRecord = teachers.TotalRecord,
            Items = dtos
        };
    }
    public async Task<TeacherDTO> Create(TeacherCreateOrUpdateDTO request)
    {
        Ensure.Any.IsNotNull(request);

        var newTeacher = _mapper.Map<Account>(request);
        newTeacher.NumberOfBreaks = 0;
        newTeacher.NumberOfHoursInClass = 0;
        newTeacher.NumberOfTeachingSessions = 0;
        newTeacher.ActualNumberOfHoursInClass = 0;
        await _teacherRepository.Add(newTeacher);
        var result = await _teacherRepository.Entities.Where(x => x.Id == newTeacher.Id)
                                                        .Include(x => x.Literacy)
                                                        .FirstOrDefaultAsync();
        if (result != null)
        {
            return _mapper.Map<TeacherDTO>(newTeacher);
        }
        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var teacher = await _teacherRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (teacher == null)
        {
            throw new NotFoundException("Not Found!");
        }
        teacher.IsDeleted = true;

        var teacherDelete = await _teacherRepository.Update(teacher);

        return teacherDelete.IsDeleted;
    }

    public async Task<List<TeacherDTO>> GetAll()
    {
        var query = Filter(
            _teacherRepository.Entities.AsQueryable(), new TeacherQueryCriteria());
        return _mapper.Map<List<TeacherDTO>>(query);
    }

    public async Task<TeacherDTO> GetById(int id)
    {
        var teacher = await _teacherRepository.Entities.Where(x => x.Id == id).Include(x => x.Literacy).FirstOrDefaultAsync();
        if (teacher == null)
        {
            throw new NotFoundException("Not Found!");
        }
        return _mapper.Map<TeacherDTO>(teacher);
    }

    public async Task<TeacherDTO> Update(int id, TeacherCreateOrUpdateDTO request)
    {
        var teacher = await _teacherRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

        if (teacher == null)
        {
            throw new NotFoundException("Not Found!");
        }

        teacher = _mapper.Map<TeacherCreateOrUpdateDTO, Account>(request, teacher);

        var teacherUpdated = await _teacherRepository.Update(teacher);
        var result = await _teacherRepository.Entities.Where(x => x.Id == teacherUpdated.Id)
                                                                .Include(x => x.Literacy)
                                                                .FirstOrDefaultAsync();
        var teacherUpdatedDTO = _mapper.Map<TeacherDTO>(result);

        return teacherUpdatedDTO;
    }

    private IQueryable<Account> Filter(
        IQueryable<Account> query,
        TeacherQueryCriteria queryCriteria)
    {
        if (!String.IsNullOrEmpty(queryCriteria.Search))
        {
            query = query.Where(b =>
                b.Name.Contains(queryCriteria.Search)
                );
        }
        query = query.Where(x => x.AccountType == AccountType.Teacher);
        query = query.Where(x => x.IsDeleted == false);

        return query.AsQueryable();
    }
}