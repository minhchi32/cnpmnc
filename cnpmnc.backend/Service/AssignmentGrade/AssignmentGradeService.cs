using AutoMapper;
using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.Extensions;
using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Enums;
using cnpmnc.shared.Exceptions;
using cnpmnc.shared.Interfaces;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class AssignmentGradeService : IAssignmentGradeService
{

    private readonly IBaseRepository<AssignmentGrade> _assignmentGradeRepository;
    private readonly IBaseRepository<Account> _teacherRepository;
    private readonly IMapper _mapper;
    public AssignmentGradeService(
        IBaseRepository<AssignmentGrade> assignmentGradeRepository,
        IBaseRepository<Account> teacherRepository,
        IMapper mapper)
    {
        _assignmentGradeRepository = assignmentGradeRepository;
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageAsync(
           AssignmentGradeQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _assignmentGradeRepository.Entities.AsQueryable(),
            queryCriteria);

        var assignmentGrades = await query
            .AsNoTracking()
            .Include(x => x.Course)
            .Include(x => x.Teacher)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<AssignmentGradeDTO>>(assignmentGrades.Items);

        return new PagedResponseModel<AssignmentGradeDTO>
        {
            Page = assignmentGrades.Page,
            TotalRecord = assignmentGrades.TotalRecord,
            Items = dtos
        };
    }

    public async Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageByTeacherIdAsync(
            int id,
           AssignmentGradeQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _assignmentGradeRepository.Entities.AsQueryable(),
            queryCriteria);

        var assignmentGrades = await query
            .AsNoTracking()
            .Include(x => x.Teacher)
            .Include(x => x.Course)
            .Where(x => x.AssignToTeacherId == id)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<AssignmentGradeDTO>>(assignmentGrades.Items);

        return new PagedResponseModel<AssignmentGradeDTO>
        {
            Page = assignmentGrades.Page,
            TotalRecord = assignmentGrades.TotalRecord,
            Items = dtos
        };
    }

    public Task<List<AssignmentGrade>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<AssignmentGradeDTO> GetById(int id)
    {
        var assignmentGrade = await _assignmentGradeRepository.Entities
                            .Where(x => x.Id == id)
                            .Include(x => x.Course)
                            .Include(x => x.Teacher)
                            .FirstOrDefaultAsync();
        if (assignmentGrade == null)
        {
            throw new NotFoundException("Not Found!");
        }
        return _mapper.Map<AssignmentGradeDTO>(assignmentGrade);
    }
    public async Task<AssignmentGradeDTO> Create(AssignmentGradeCreateOrUpdateDTO request)
    {
        Ensure.Any.IsNotNull(request);

        var newAssignmentGrade = _mapper.Map<AssignmentGrade>(request);
        newAssignmentGrade.State = AssignmentGradeStateEnumDto.WaitingForAcceptance;
        newAssignmentGrade.Total = 40;
        newAssignmentGrade.AssignDate = DateTime.Now;
        switch (DateTime.Now.Date.Month)
        {
            case 1:
            case 2:
            case 3:
                newAssignmentGrade.Semester = SemesterEnumDto.Semester2;
                break;
            case 4:
            case 5:
            case 6:
                newAssignmentGrade.Semester = SemesterEnumDto.Semester3;
                break;
            case 7:
            case 8:
            case 9:
                newAssignmentGrade.Semester = SemesterEnumDto.Semester4;
                break;
            case 10:
            case 11:
            case 12:
                newAssignmentGrade.Semester = SemesterEnumDto.Semester1;
                break;
        }
        newAssignmentGrade.Semester = SemesterEnumDto.Semester1;
        await _assignmentGradeRepository.Add(newAssignmentGrade);
        var result = await _assignmentGradeRepository.Entities.Where(x => x.Id == newAssignmentGrade.Id)
                                                        .Include(x => x.Course)
                                                        .Include(x => x.Teacher)
                                                        .FirstOrDefaultAsync();
        if (result != null)
        {
            return _mapper.Map<AssignmentGradeDTO>(newAssignmentGrade);
        }
        return null;
    }
    public async Task<AssignmentGradeDTO> Update(int id, AssignmentGradeCreateOrUpdateDTO request)
    {
        var assignmentGrade = await _assignmentGradeRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

        if (assignmentGrade == null)
        {
            throw new NotFoundException("Not Found!");
        }

        assignmentGrade = _mapper.Map<AssignmentGradeCreateOrUpdateDTO, AssignmentGrade>(request, assignmentGrade);

        var assignmentGradeUpdated = await _assignmentGradeRepository.Update(assignmentGrade);
        var result = await _assignmentGradeRepository.Entities.Where(x => x.Id == assignmentGradeUpdated.Id)
                                                                .Include(x => x.Course)
                                                                .Include(x => x.Teacher)
                                                                .FirstOrDefaultAsync();
        var assignmentGradeUpdatedDTO = _mapper.Map<AssignmentGradeDTO>(result);

        return assignmentGradeUpdatedDTO;
    }
    public async Task<bool> Delete(int id)
    {
        var assignmentGrade = await _assignmentGradeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (assignmentGrade == null)
        {
            throw new NotFoundException("Not Found!");
        }
        if (assignmentGrade.State == AssignmentGradeStateEnumDto.WaitingForAcceptance)
        {
            var assignmentGradeDelete = await _assignmentGradeRepository.Delete(assignmentGrade);

            return true;
        }
        return false;

    }
    public async Task<AssignmentGradeDTO> RespondToAssignmentGrade(AssignmentGradeResponseDTO dto, int userId)
    {
        var assignmentGrade = _assignmentGradeRepository.Entities
                .Where(q => q.Id == dto.AssignmentGradeID)
                .Include(x => x.Course)
                .Include(x => x.Teacher)
                .FirstOrDefault();
        var teacher = await _teacherRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == userId);
        if (assignmentGrade == null)
        {
            throw new NotFoundException("AssignmentGrade Not Found!");
        }
        if (teacher == null)
        {
            throw new NotFoundException("Teacher Not Found!");
        }
        if (teacher.Id != assignmentGrade.AssignToTeacherId)
        {
            throw new ErrorException($"Teacher is not assigned to this assignmentGrade!");
        }
        AssignmentGrade updatedAssignmentGrade;

        assignmentGrade.State = dto.Response == AssignmentGradeResponseEnumDto.Accepted
                            ? AssignmentGradeStateEnumDto.Accepted
                            : AssignmentGradeStateEnumDto.Declined;

        updatedAssignmentGrade = await _assignmentGradeRepository.Update(assignmentGrade);

        AssignmentGradeDTO assignmentGradeDTO = _mapper.Map<AssignmentGradeDTO>(assignmentGrade);
        return assignmentGradeDTO;
    }
    private IQueryable<AssignmentGrade> Filter(
             IQueryable<AssignmentGrade> assignmentGradeQuery,
             AssignmentGradeQueryCriteria assignmentGradeQueryCriteria)
    {
        if (!String.IsNullOrEmpty(assignmentGradeQueryCriteria.Search))
        {
            assignmentGradeQuery = assignmentGradeQuery.Where(b =>
                b.Course.Name.Contains(assignmentGradeQueryCriteria.Search) ||
                b.Teacher.Name.Contains(assignmentGradeQueryCriteria.Search)
                );
        }
        return assignmentGradeQuery;
    }
}