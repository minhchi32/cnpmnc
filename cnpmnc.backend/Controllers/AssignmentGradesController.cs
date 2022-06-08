using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentGradesController : ControllerBase
{

    private readonly IAssignmentGradeService _assignmentGradeService;

    public AssignmentGradesController(IAssignmentGradeService assignmentGradeService)
    {
        _assignmentGradeService = assignmentGradeService;
    }

    [HttpGet("paging")]
    public async Task<ActionResult<PagedResponseModel<AssignmentGradeDTO>>> GetAssignmentGrades(
        int id,
        [FromQuery] AssignmentGradeQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _assignmentGradeService.GetByPageAsync(
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("paging/{id}")]
    public async Task<ActionResult<PagedResponseModel<AssignmentGradeDTO>>> GetAssignmentGradeByTeacherId(int id,
        [FromQuery] AssignmentGradeQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _assignmentGradeService.GetByPageByTeacherIdAsync(
                                        id,
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PagedResponseModel<AssignmentGradeDTO>>> GetAssignmentGrade(int id)
    {
        var responses = await _assignmentGradeService.GetById(id);
        return Ok(responses);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssignmentGradeCreateOrUpdateDTO createDTO)
    {
        var validationResult = new AssignmentGradeCreateOrUpdateDTOValidator().Validate(createDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _assignmentGradeService.Create(createDTO);
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
        [FromBody] AssignmentGradeCreateOrUpdateDTO updateDTO)
    {
        Ensure.Any.IsNotNull(updateDTO, nameof(updateDTO));

        var validationResult = new AssignmentGradeCreateOrUpdateDTOValidator().Validate(updateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var updatedAssignmentGrade = await _assignmentGradeService.Update(id, updateDTO);
            if (updatedAssignmentGrade != null)
            {
                return Ok(updatedAssignmentGrade);
            }
            else
            {
                return BadRequest(updatedAssignmentGrade);
            }
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _assignmentGradeService.Delete(id);
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
    public async Task<ActionResult<AssignmentGradeDTO>> RespondToAssignmentGrade(
        int userId,
        [FromBody] AssignmentGradeResponseDTO dto)
    {
        var validationResult = new AssignmentGradeResponseDTOValidator().Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _assignmentGradeService.RespondToAssignmentGrade(dto, userId);
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
