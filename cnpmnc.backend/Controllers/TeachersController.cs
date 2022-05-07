using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{

    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("paging")]
    public async Task<ActionResult<PagedResponseModel<TeacherDTO>>> GetTeachers(
        [FromQuery] TeacherQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _teacherService.GetByPageAsync(
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PagedResponseModel<TeacherDTO>>> GetTeacher(int id)
    {
        var responses = await _teacherService.GetById(id);
        return Ok(responses);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TeacherCreateOrUpdateDTO createDTO)
    {
        var validationResult = new TeacherCreateOrUpdateDTOValidator().Validate(createDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _teacherService.Create(createDTO);
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
        [FromBody] TeacherCreateOrUpdateDTO updateDTO)
    {
        Ensure.Any.IsNotNull(updateDTO, nameof(updateDTO));

        var validationResult = new TeacherCreateOrUpdateDTOValidator().Validate(updateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var updatedTeacher = await _teacherService.Update(id, updateDTO);
            if (updatedTeacher != null)
            {
                return Ok(updatedTeacher);
            }
            else
            {
                return BadRequest(updatedTeacher);
            }
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _teacherService.Delete(id);
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
