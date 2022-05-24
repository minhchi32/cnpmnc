using AutoMapper;
using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.DTOs.GradeDTOs;
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

class AssignmentService : IAssignmentService
{

    private readonly IBaseRepository<Assignment> _assignmentRepository;
    private readonly IBaseRepository<Account> _teacherRepository;
    private readonly IMapper _mapper;
    public AssignmentService(
        IBaseRepository<Assignment> assignmentRepository,
        IBaseRepository<Account> teacherRepository,
        IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(
           AssignmentQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _assignmentRepository.Entities.AsQueryable(),
            queryCriteria);

        var assignments = await query
            .AsNoTracking()
            .Include(x => x.Course)
            .Include(x => x.Teacher)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<AssignmentDTO>>(assignments.Items);

        return new PagedResponseModel<AssignmentDTO>
        {
            Page = assignments.Page,
            TotalRecord = assignments.TotalRecord,
            Items = dtos
        };
    }

    public async Task<PagedResponseModel<AssignmentDTO>> GetByPageByTeacherIdAsync(
            int id,
           AssignmentQueryCriteria queryCriteria,
           CancellationToken cancellationToken)
    {

        var query = Filter(
            _assignmentRepository.Entities.AsQueryable(),
            queryCriteria);

        var assignments = await query
            .AsNoTracking()
            .Where(x => x.Teacher.Id == id)
            .Include(x => x.Course)
            .PaginateAsync(
                queryCriteria,
                cancellationToken);

        var dtos = _mapper.Map<IList<AssignmentDTO>>(assignments.Items);

        return new PagedResponseModel<AssignmentDTO>
        {
            Page = assignments.Page,
            TotalRecord = assignments.TotalRecord,
            Items = dtos
        };
    }

    public Task<List<Assignment>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<AssignmentDTO> GetById(int id)
    {
        var assignment = await _assignmentRepository.Entities
                            .Where(x => x.Id == id)
                            .Include(x => x.Course)
                            .Include(x => x.Teacher)
                            .FirstOrDefaultAsync();
        if (assignment == null)
        {
            throw new NotFoundException("Not Found!");
        }
        return _mapper.Map<AssignmentDTO>(assignment);
    }
    public async Task<AssignmentDTO> Create(AssignmentCreateOrUpdateDTO request)
    {
        Ensure.Any.IsNotNull(request);

        var newAssignment = _mapper.Map<Assignment>(request);
        newAssignment.State = AssignmentStateEnumDto.WaitingForAcceptance;
        await _assignmentRepository.Add(newAssignment);
        var result = await _assignmentRepository.Entities.Where(x => x.Id == newAssignment.Id)
                                                        .Include(x => x.Course)
                                                        .Include(x => x.Teacher)
                                                        .FirstOrDefaultAsync();
        if (result != null)
        {
            return _mapper.Map<AssignmentDTO>(newAssignment);
        }
        return null;
    }
    public async Task<AssignmentDTO> Update(int id, AssignmentCreateOrUpdateDTO request)
    {
        var assignment = await _assignmentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

        if (assignment == null)
        {
            throw new NotFoundException("Not Found!");
        }

        assignment = _mapper.Map<AssignmentCreateOrUpdateDTO, Assignment>(request, assignment);

        var assignmentUpdated = await _assignmentRepository.Update(assignment);
        var result = await _assignmentRepository.Entities.Where(x => x.Id == assignmentUpdated.Id)
                                                                .Include(x => x.Course)
                                                                .Include(x => x.Teacher)
                                                                .FirstOrDefaultAsync();
        var assignmentUpdatedDTO = _mapper.Map<AssignmentDTO>(result);

        return assignmentUpdatedDTO;
    }
    public async Task<bool> Delete(int id)
    {
        var assignment = await _assignmentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (assignment == null)
        {
            throw new NotFoundException("Not Found!");
        }
        assignment.IsDeleted = true;

        var assignmentDelete = await _assignmentRepository.Update(assignment);

        return assignmentDelete.IsDeleted;
    }
    public async Task<AssignmentDTO> RespondToAssignment(AssignmentResponseDTO dto, int userId)
    {
        var assignment = _assignmentRepository.Entities
                .Where(q => q.Id == dto.AssignmentID)
                .Include(x => x.Course)
                .Include(x => x.Teacher)
                .FirstOrDefault();
        // var teacher = _teacherRepository.Entities.Where(q => q.Id == userId).FirstOrDefault();
        var teacher = await _teacherRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == userId);
        if (assignment == null)
        {
            throw new NotFoundException("Assignment Not Found!");
        }
        if (teacher == null)
        {
            throw new NotFoundException("Teacher Not Found!");
        }
        if (teacher.Id != assignment.AssignToTeacherId)
        {
            throw new ErrorException($"Teacher is not assigned to this assignment!");
        }
        Assignment updatedAssignment;

        assignment.State = dto.Response == AssignmentResponseEnumDto.Accepted
                            ? AssignmentStateEnumDto.Accepted
                            : AssignmentStateEnumDto.Declined;

        updatedAssignment = await _assignmentRepository.Update(assignment);

        AssignmentDTO assignmentDTO = _mapper.Map<AssignmentDTO>(assignment);
        return assignmentDTO;
    }
    private IQueryable<Assignment> Filter(
             IQueryable<Assignment> assignmentQuery,
             AssignmentQueryCriteria assignmentQueryCriteria)
    {
        if (!String.IsNullOrEmpty(assignmentQueryCriteria.Search))
        {
            assignmentQuery = assignmentQuery.Where(b =>
                b.Course.Name.Contains(assignmentQueryCriteria.Search) ||
                b.Teacher.Name.Contains(assignmentQueryCriteria.Search)
                );
        }
        if (assignmentQueryCriteria.State != null &&
         assignmentQueryCriteria.State.Count() > 0)
        {
            assignmentQuery = assignmentQuery.Where(x =>
                assignmentQueryCriteria.State.Any(t => t == (int)x.State));
        }
        if (assignmentQueryCriteria.AssignedDate != DateTime.MinValue)
        {
            assignmentQuery = assignmentQuery.Where(x => x.AssignDate.Date == assignmentQueryCriteria.AssignedDate.Date);
        }
        if (assignmentQueryCriteria.SortColumn == "state")
        {
            assignmentQuery = assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending
                ? assignmentQuery.OrderBy(p =>
                 p.State == AssignmentStateEnumDto.WaitingForAcceptance ? "WaitingForAcceptance" :
                 p.State == AssignmentStateEnumDto.Accepted ? "Accepted" :
                 p.State == AssignmentStateEnumDto.Declined ? "Declined" :
                 "ZZZ"
                )
                : assignmentQuery.OrderByDescending(p =>
                 p.State == AssignmentStateEnumDto.WaitingForAcceptance ? "WaitingForAcceptance" :
                 p.State == AssignmentStateEnumDto.Accepted ? "Accepted" :
                 p.State == AssignmentStateEnumDto.Declined ? "Declined" :
                 "ZZZ");
            assignmentQueryCriteria.SortColumn = null;
        }
        // if (assignmentQueryCriteria.SortColumn == "name")
        // {
        //     assignmentQuery =
        //         assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending ?
        //         assignmentQuery.OrderBy(q => q.Asset.Name)
        //         :
        //         assignmentQuery.OrderByDescending(q => q.Asset.Name);
        //     assignmentQueryCriteria.SortColumn = null;
        // }
        // if (assignmentQueryCriteria.SortColumn == "code")
        // {
        //     assignmentQuery =
        //         assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending ?
        //         assignmentQuery.OrderBy(q => q.Asset.Code)
        //         :
        //         assignmentQuery.OrderByDescending(q => q.Asset.Code);
        //     assignmentQueryCriteria.SortColumn = null;
        // }
        //not showing deleted 
        assignmentQuery = assignmentQuery.Where(x => x.IsDeleted == false);
        return assignmentQuery;
    }
}