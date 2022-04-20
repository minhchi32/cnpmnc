using cnpmnc.backend.DTOs.Course;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{

    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponseModel<CourseDTO>>> GetCourses(
        [FromQuery] CourseQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _courseService.GetByPageAsync(
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CourseCreateDTO createDTO)
    {
        var validationResult = new CourseCreateDTOValidator().Validate(createDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var result = await _courseService.Create(createDTO);
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
        [FromBody] CourseUpdateDTO updateDTO)
    {
        Ensure.Any.IsNotNull(updateDTO, nameof(updateDTO));

        var validationResult = new CourseUpdateDTOValidator().Validate(updateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        else
        {
            var updatedCourse = await _courseService.Update(id, updateDTO);
            if (updatedCourse != null)
            {
                return Ok(updatedCourse);
            }
            else
            {
                return BadRequest(updatedCourse);
            }
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _courseService.Delete(id);
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
