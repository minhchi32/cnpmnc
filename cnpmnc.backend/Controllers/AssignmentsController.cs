using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{

    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet("paging")]
    public async Task<ActionResult<PagedResponseModel<AssignmentDTO>>> GetAssignments(
        int id,
        [FromQuery] AssignmentQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _assignmentService.GetByPageAsync(
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("paging/{id}")]
    public async Task<ActionResult<PagedResponseModel<AssignmentDTO>>> GetAssignmentByTeacherId(int id,
        [FromQuery] AssignmentQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _assignmentService.GetByPageByTeacherIdAsync(
                                        id,
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PagedResponseModel<AssignmentDTO>>> GetAssignment(int id)
    {
        var responses = await _assignmentService.GetById(id);
        return Ok(responses);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssignmentCreateOrUpdateDTO createDTO)
    {
        var validationResult = new AssignmentCreateOrUpdateDTOValidator().Validate(createDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _assignmentService.Create(createDTO);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] AssignmentCreateOrUpdateDTO updateDTO)
    {
        Ensure.Any.IsNotNull(updateDTO, nameof(updateDTO));

        var validationResult = new AssignmentCreateOrUpdateDTOValidator().Validate(updateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var updatedAssignment = await _assignmentService.Update(id, updateDTO);
            if (updatedAssignment != null)
            {
                return Ok(updatedAssignment);
            }
            else
            {
                return BadRequest(updatedAssignment);
            }
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _assignmentService.Delete(id);
        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }

    [HttpPut("respond")]
    public async Task<ActionResult<AssignmentDTO>> RespondToAssignment(
        int userId,
        [FromBody] AssignmentResponseDTO dto)
    {
        var validationResult = new AssignmentResponseDTOValidator().Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _assignmentService.RespondToAssignment(dto, userId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
